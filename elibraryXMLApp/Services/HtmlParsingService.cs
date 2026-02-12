using System.Text.RegularExpressions;
using HtmlAgilityPack;
using elibraryXMLApp.Models;

namespace elibraryXMLApp.Services;

/// <summary>
/// Service for parsing HTML files and extracting article metadata
/// </summary>
public class HtmlParsingService : IHtmlParsingService
{
    // Constants for parsing
    private const string UNKNOWN_INITIALS = "X.X.";
    
    // Pattern for author names in "Surname I.I." format (supports both Cyrillic and Latin)
    private const string AUTHOR_PATTERN = @"([А-ЯЁA-Z][а-яёa-z]+(?:\s+[А-ЯЁA-Z][а-яёa-z]+)*)\s+([А-ЯЁA-Z]\.[А-ЯЁA-Z]\.)";
    
    /// <summary>
    /// Parse HTML file and create a Journal with extracted articles
    /// </summary>
    public Journal ParseHtmlFile(string htmlFilePath)
    {
        var htmlContent = File.ReadAllText(htmlFilePath);
        return ParseHtmlContent(htmlContent);
    }

    /// <summary>
    /// Parse HTML content and create a Journal with extracted articles
    /// </summary>
    public Journal ParseHtmlContent(string htmlContent)
    {
        var doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(htmlContent);

        var journal = new Journal
        {
            JournalInfo = new JournalInfo(),
            Issue = new Issue { Articles = new Articles() }
        };

        // Try to extract issue title
        var issueTitle = ExtractIssueTitle(doc);
        if (!string.IsNullOrEmpty(issueTitle))
        {
            journal.Issue.IssTitle = new IssTitle { Value = issueTitle, Lang = "RUS" };
        }

        // Try to extract articles from various HTML structures
        var articles = ExtractArticles(doc);
        journal.Issue.Articles.ArticleList = articles;

        return journal;
    }

    /// <summary>
    /// Extract issue title from HTML document
    /// </summary>
    private string? ExtractIssueTitle(HtmlAgilityPack.HtmlDocument doc)
    {
        // Try common patterns for issue titles
        var titleSelectors = new[]
        {
            "//h1",
            "//title",
            "//div[@class='issue-title']",
            "//div[@class='issue-header']//h1",
            "//div[@id='issue-title']"
        };

        foreach (var selector in titleSelectors)
        {
            var node = doc.DocumentNode.SelectSingleNode(selector);
            if (node != null && !string.IsNullOrWhiteSpace(node.InnerText))
            {
                var text = CleanText(node.InnerText);
                if (text.Length > 5 && text.Length < 200)
                {
                    return text;
                }
            }
        }

        return null;
    }

    /// <summary>
    /// Extract articles from HTML document
    /// </summary>
    private List<Article> ExtractArticles(HtmlAgilityPack.HtmlDocument doc)
    {
        var articles = new List<Article>();

        // Try to find article containers with common patterns
        var articleContainerSelectors = new[]
        {
            "//article",
            "//div[@class='article']",
            "//div[contains(@class, 'article-item')]",
            "//div[contains(@class, 'toc-item')]",
            "//li[contains(@class, 'article')]",
            "//tr[contains(@class, 'article')]",
            "//div[@class='item']"
        };

        foreach (var selector in articleContainerSelectors)
        {
            var nodes = doc.DocumentNode.SelectNodes(selector);
            if (nodes != null && nodes.Count > 0)
            {
                foreach (var node in nodes)
                {
                    var article = ExtractArticleFromNode(node);
                    if (article != null)
                    {
                        articles.Add(article);
                    }
                }

                // If we found articles, stop looking
                if (articles.Count > 0)
                {
                    break;
                }
            }
        }

        // If no articles found with containers, try to extract from text content
        if (articles.Count == 0)
        {
            articles = ExtractArticlesFromText(doc);
        }

        return articles;
    }

    /// <summary>
    /// Extract article data from HTML node
    /// </summary>
    private Article? ExtractArticleFromNode(HtmlNode node)
    {
        var article = new Article
        {
            ArtType = "RAR",
            Authors = new List<Author>()
        };

        // Extract title
        var titleNode = node.SelectSingleNode(".//h2 | .//h3 | .//a | .//span[@class='title'] | .//div[@class='title']");
        if (titleNode != null)
        {
            var title = CleanText(titleNode.InnerText);
            if (!string.IsNullOrWhiteSpace(title) && title.Length > 5)
            {
                article.ArtTitles = new ArtTitles
                {
                    TitleList = new List<ArtTitle>
                    {
                        new ArtTitle { Value = title, Lang = "RUS" }
                    }
                };
            }
        }

        // Extract authors
        var authorNodes = node.SelectNodes(".//span[contains(@class, 'author')] | .//div[contains(@class, 'author')] | .//a[contains(@class, 'author')]");
        if (authorNodes != null)
        {
            int authorNum = 1;
            foreach (var authorNode in authorNodes)
            {
                var authorText = CleanText(authorNode.InnerText);
                if (!string.IsNullOrWhiteSpace(authorText))
                {
                    var author = ParseAuthorText(authorText, authorNum++);
                    if (author != null)
                    {
                        article.Authors.Add(author);
                    }
                }
            }
        }

        // If no structured authors found, try to extract from text
        if (article.Authors.Count == 0)
        {
            var nodeText = node.InnerText;
            var extractedAuthors = ExtractAuthorsFromText(nodeText);
            int num = 1;
            foreach (var authorText in extractedAuthors)
            {
                var author = ParseAuthorText(authorText, num++);
                if (author != null)
                {
                    article.Authors.Add(author);
                }
            }
        }

        // Extract pages
        // Pattern matches both Russian ('с.') and English ('p./pp./pages') page number formats
        var pagesPattern = @"(?:с\.|pp?\.|pages?:?\s*)?(\d+)\s*[-–—]\s*(\d+)";
        var pagesMatch = Regex.Match(node.InnerText, pagesPattern, RegexOptions.IgnoreCase);
        if (pagesMatch.Success)
        {
            article.Pages = $"{pagesMatch.Groups[1].Value}-{pagesMatch.Groups[2].Value}";
        }

        // Extract DOI
        var doiPattern = @"(?:doi[:\s]*)?(\b10\.\d{4,}(?:\.\d+)*\/[^\s<>]+)";
        var doiMatch = Regex.Match(node.InnerText, doiPattern, RegexOptions.IgnoreCase);
        if (doiMatch.Success)
        {
            if (article.Codes == null)
                article.Codes = new ArticleCodes();
            article.Codes.Doi = doiMatch.Groups[1].Value.Trim();
        }

        // Only return article if it has at least a title
        if (article.ArtTitles != null && article.ArtTitles.TitleList.Count > 0)
        {
            return article;
        }

        return null;
    }

    /// <summary>
    /// Extract articles from text when no HTML structure is found
    /// </summary>
    private List<Article> ExtractArticlesFromText(HtmlAgilityPack.HtmlDocument doc)
    {
        var articles = new List<Article>();
        var textParsingService = new TextParsingService();

        // Get all text content
        var bodyNode = doc.DocumentNode.SelectSingleNode("//body");
        if (bodyNode == null)
            return articles;

        var text = CleanText(bodyNode.InnerText);
        
        // Split by common article separators
        var articleTexts = SplitIntoArticleSections(text);

        foreach (var articleText in articleTexts)
        {
            if (articleText.Length < 50) // Skip very short sections
                continue;

            var parsedData = textParsingService.ParseArticleText(articleText);
            
            // Create article if we have at least a title
            if (parsedData.Titles.Any())
            {
                var article = new Article
                {
                    ArtType = "RAR",
                    Pages = parsedData.Pages ?? string.Empty,
                    Authors = new List<Author>()
                };

                // Set titles
                article.ArtTitles = new ArtTitles { TitleList = new List<ArtTitle>() };
                foreach (var title in parsedData.Titles.Take(2)) // Take max 2 titles
                {
                    article.ArtTitles.TitleList.Add(new ArtTitle
                    {
                        Value = title,
                        Lang = DetectLanguage(title)
                    });
                }

                // Set DOI if found
                if (!string.IsNullOrEmpty(parsedData.Doi))
                {
                    article.Codes = new ArticleCodes { Doi = parsedData.Doi };
                }

                // Add authors
                int authorNum = 1;
                foreach (var authorText in parsedData.Authors)
                {
                    var author = ParseAuthorText(authorText, authorNum++);
                    if (author != null)
                    {
                        article.Authors.Add(author);
                    }
                }

                articles.Add(article);
            }
        }

        return articles;
    }

    /// <summary>
    /// Split text into article sections
    /// </summary>
    private List<string> SplitIntoArticleSections(string text)
    {
        var sections = new List<string>();

        // Try to split by page number patterns or multiple newlines
        var lines = text.Split('\n');
        var currentSection = new List<string>();

        foreach (var line in lines)
        {
            var trimmedLine = line.Trim();

            // Check if this looks like an article separator
            if (string.IsNullOrWhiteSpace(trimmedLine) && currentSection.Count > 10)
            {
                // Multiple empty lines might indicate section break
                sections.Add(string.Join("\n", currentSection));
                currentSection.Clear();
            }
            else if (!string.IsNullOrWhiteSpace(trimmedLine))
            {
                currentSection.Add(trimmedLine);
            }
        }

        // Add last section
        if (currentSection.Count > 0)
        {
            sections.Add(string.Join("\n", currentSection));
        }

        return sections;
    }

    /// <summary>
    /// Extract authors from text using regex patterns
    /// </summary>
    private List<string> ExtractAuthorsFromText(string text)
    {
        var authors = new List<string>();

        var matches = Regex.Matches(text, AUTHOR_PATTERN);

        foreach (Match match in matches)
        {
            var author = match.Value.Trim();
            if (!authors.Contains(author) && author.Length < 100)
            {
                authors.Add(author);
            }
        }

        return authors;
    }

    /// <summary>
    /// Parse author text into Author object
    /// </summary>
    private Author? ParseAuthorText(string authorText, int authorNum)
    {
        if (string.IsNullOrWhiteSpace(authorText))
            return null;

        // Try to parse "Surname I.I." format
        var match = Regex.Match(authorText, AUTHOR_PATTERN);
        
        if (match.Success)
        {
            return new Author
            {
                Num = (ushort)authorNum,
                IndividInfoList = new List<IndividInfo>
                {
                    new IndividInfo
                    {
                        Lang = "RUS",
                        Surname = match.Groups[1].Value.Trim(),
                        Initials = match.Groups[2].Value.Trim()
                    }
                }
            };
        }

        // If no match, try to split by space and use first part as surname
        var parts = authorText.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length >= 1)
        {
            return new Author
            {
                Num = (ushort)authorNum,
                IndividInfoList = new List<IndividInfo>
                {
                    new IndividInfo
                    {
                        Lang = "RUS",
                        Surname = parts[0],
                        Initials = parts.Length > 1 ? parts[1] : UNKNOWN_INITIALS
                    }
                }
            };
        }

        return null;
    }

    /// <summary>
    /// Detect language of text (simple heuristic)
    /// </summary>
    private string DetectLanguage(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return "RUS";

        // Count Cyrillic characters
        int cyrillicCount = text.Count(c => (c >= 'А' && c <= 'я') || c == 'Ё' || c == 'ё');
        int totalLetters = text.Count(char.IsLetter);

        // If more than 30% are Cyrillic, it's Russian
        return (totalLetters > 0 && cyrillicCount > totalLetters * 0.3) ? "RUS" : "ENG";
    }

    /// <summary>
    /// Clean HTML text by removing extra whitespace and HTML entities
    /// </summary>
    private string CleanText(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return string.Empty;

        // Decode HTML entities
        text = System.Net.WebUtility.HtmlDecode(text);

        // Remove extra whitespace
        text = Regex.Replace(text, @"\s+", " ");
        
        return text.Trim();
    }
}
