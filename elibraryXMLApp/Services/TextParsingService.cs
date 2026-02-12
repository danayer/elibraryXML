using System.Text.RegularExpressions;
using elibraryXMLApp.Models;

namespace elibraryXMLApp.Services;

/// <summary>
/// Service for manual text parsing and metadata extraction
/// </summary>
public class TextParsingService : ITextParsingService
{
    /// <summary>
    /// Parse text and extract article metadata
    /// </summary>
    public ParsedArticleData ParseArticleText(string sourceText)
    {
        var data = new ParsedArticleData();
        
        if (string.IsNullOrWhiteSpace(sourceText))
            return data;

        var lines = sourceText.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(l => l.Trim())
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .ToList();

        // Extract DOI
        data.Doi = ExtractDoi(sourceText);
        
        // Extract titles (first few non-empty lines, often the title)
        data.Titles = ExtractTitles(lines);
        
        // Extract authors
        data.Authors = ExtractAuthors(sourceText);
        
        // Extract emails
        data.Emails = ExtractEmails(sourceText);
        
        // Extract keywords
        data.Keywords = ExtractKeywords(sourceText);
        
        // Extract abstract
        data.Abstract = ExtractAbstract(lines);
        
        // Extract pages
        data.Pages = ExtractPages(sourceText);
        
        // Extract year
        data.Year = ExtractYear(sourceText);

        return data;
    }

    private string? ExtractDoi(string text)
    {
        // Match DOI patterns like 10.1234/example or doi:10.1234/example
        var doiPattern = @"(?:doi[:\s]*)?(\b10\.\d{4,}(?:\.\d+)*\/[^\s]+)";
        var match = Regex.Match(text, doiPattern, RegexOptions.IgnoreCase);
        
        if (match.Success)
        {
            return match.Groups[1].Value.Trim();
        }
        
        return null;
    }

    private List<string> ExtractTitles(List<string> lines)
    {
        var titles = new List<string>();
        
        // Take first 1-3 lines as potential titles
        // Usually title is at the beginning and is longer
        for (int i = 0; i < Math.Min(3, lines.Count); i++)
        {
            var line = lines[i];
            
            // Skip very short lines (likely not titles)
            if (line.Length < 10)
                continue;
                
            // Skip lines that look like metadata (DOI, pages, etc.)
            if (Regex.IsMatch(line, @"^\d+[-–]\d+$|^doi:|^УДК|^UDC", RegexOptions.IgnoreCase))
                continue;
                
            titles.Add(line);
            
            // If we found a reasonably long title, we can stop
            if (line.Length > 30)
                break;
        }
        
        return titles;
    }

    private List<string> ExtractAuthors(string text)
    {
        var authors = new List<string>();
        
        // Pattern for author names like "Иванов И.И." or "Ivanov I.I."
        var authorPattern = @"([А-ЯЁA-Z][а-яёa-z]+(?:\s+[А-ЯЁA-Z][а-яёa-z]+)*)\s+([А-ЯЁA-Z]\.[А-ЯЁA-Z]\.)";
        var matches = Regex.Matches(text, authorPattern);
        
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

    private List<string> ExtractEmails(string text)
    {
        var emails = new List<string>();
        
        // Email pattern
        var emailPattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";
        var matches = Regex.Matches(text, emailPattern);
        
        foreach (Match match in matches)
        {
            var email = match.Value.ToLower();
            if (!emails.Contains(email))
            {
                emails.Add(email);
            }
        }
        
        return emails;
    }

    private List<string> ExtractKeywords(string text)
    {
        var keywords = new List<string>();
        
        // Look for keywords section
        var keywordPatterns = new[]
        {
            @"Ключевые слова[:\s]*(.+?)(?:\n\n|\n[А-ЯA-Z])",
            @"Keywords[:\s]*(.+?)(?:\n\n|\n[А-ЯA-Z])",
            @"Key words[:\s]*(.+?)(?:\n\n|\n[А-ЯA-Z])"
        };
        
        foreach (var pattern in keywordPatterns)
        {
            var match = Regex.Match(text, pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (match.Success)
            {
                var kwText = match.Groups[1].Value;
                // Split by comma, semicolon, or newline
                var kws = kwText.Split(new[] { ',', ';', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(k => k.Trim())
                    .Where(k => !string.IsNullOrWhiteSpace(k) && k.Length > 2 && k.Length < 100);
                
                keywords.AddRange(kws);
            }
        }
        
        return keywords.Distinct().ToList();
    }

    private string? ExtractAbstract(List<string> lines)
    {
        // Look for abstract markers
        var abstractMarkers = new[] { "аннотация", "abstract", "резюме", "summary" };
        
        for (int i = 0; i < lines.Count; i++)
        {
            var line = lines[i].ToLower();
            
            if (abstractMarkers.Any(m => line.Contains(m)))
            {
                // Collect next few lines as abstract
                var abstractLines = new List<string>();
                for (int j = i + 1; j < Math.Min(i + 15, lines.Count); j++)
                {
                    var nextLine = lines[j];
                    
                    // Stop if we hit another section marker
                    if (Regex.IsMatch(nextLine, @"^(Введение|Introduction|Ключевые слова|Keywords)", RegexOptions.IgnoreCase))
                        break;
                        
                    abstractLines.Add(nextLine);
                }
                
                if (abstractLines.Any())
                {
                    return string.Join(" ", abstractLines);
                }
            }
        }
        
        return null;
    }

    private string? ExtractPages(string text)
    {
        // Pattern for page ranges like "123-145" or "с. 123-145"
        var pagePattern = @"(?:с\.|pp?\.|pages?)?\s*(\d+)\s*[-–]\s*(\d+)";
        var match = Regex.Match(text, pagePattern, RegexOptions.IgnoreCase);
        
        if (match.Success)
        {
            return $"{match.Groups[1].Value}-{match.Groups[2].Value}";
        }
        
        return null;
    }

    private int? ExtractYear(string text)
    {
        // Pattern for 4-digit year (2020-2030)
        var yearPattern = @"\b(202\d|201\d|200\d)\b";
        var match = Regex.Match(text, yearPattern);
        
        if (match.Success && int.TryParse(match.Value, out int year))
        {
            return year;
        }
        
        return null;
    }
}

/// <summary>
/// Parsed article data with all possible parameters
/// </summary>
public class ParsedArticleData
{
    /// <summary>
    /// Default article type constant: "RAR" (Research Article/Report)
    /// </summary>
    public const string DefaultArticleType = "RAR";
    
    // Basic Info
    public string? Doi { get; set; }
    public List<string> Titles { get; set; } = new List<string>();
    public List<string> Authors { get; set; } = new List<string>();
    public List<string> Emails { get; set; } = new List<string>();
    public List<string> Keywords { get; set; } = new List<string>();
    public string? Abstract { get; set; }
    public string? Pages { get; set; }
    public int? Year { get; set; }
    
    // Article Type and Language
    /// <summary>
    /// Article type. Default is "RAR" (Research Article/Report)
    /// </summary>
    public string ArtType { get; set; } = DefaultArticleType;
    public string? LangPubl { get; set; }
    
    // Text content (full text)
    public string? TextContent { get; set; }
    
    // Additional Codes
    public string? Edn { get; set; }
    public string? Udk { get; set; }
    public string? Bbk { get; set; }
    public string? Vak { get; set; }
    public string? Jel { get; set; }
    public string? Msc { get; set; }
    public string? Pacs { get; set; }
    
    // Author Codes (for first/corresponding author)
    public string? Orcid { get; set; }
    public string? Spin { get; set; }
    public string? ScopusId { get; set; }
    public string? ResearcherId { get; set; }
    
    // Author Organizations
    public string? OrgName { get; set; }
    
    // Dates
    public string? DateReceived { get; set; }
    public string? DateAccepted { get; set; }
    public string? DatePublication { get; set; }
    
    // Funding
    public List<string> Fundings { get; set; } = new List<string>();
    
    // Rubrics
    public List<string> Rubrics { get; set; } = new List<string>();
    
    // Files
    public List<string> Files { get; set; } = new List<string>();
    
    // References
    public List<string> References { get; set; } = new List<string>();
}
