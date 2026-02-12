using System.Text;
using System.Xml;
using elibraryXMLApp.Models;

namespace elibraryXMLApp.Services;

/// <summary>
/// Service for exporting to journal3 XML format (for "Metaphor" IS)
/// All articles are exported to a single XML file
/// </summary>
public class Journal3ExportService : IJournal3ExportService
{
    /// <summary>
    /// Export entire journal to journal3 XML format
    /// </summary>
    public void ExportToJournal3(Journal journal, string filePath)
    {
        var settings = new XmlWriterSettings
        {
            Indent = true,
            IndentChars = "  ",
            Encoding = Encoding.UTF8,
            OmitXmlDeclaration = false
        };

        using var writer = XmlWriter.Create(filePath, settings);
        
        writer.WriteStartDocument();
        
        // Root element
        writer.WriteStartElement("journal3");
        
        // Journal metadata
        WriteJournalMetadata(writer, journal);
        
        // Issue metadata
        WriteIssueMetadata(writer, journal.Issue);
        
        // Articles
        WriteArticles(writer, journal.Issue.Articles);
        
        writer.WriteEndElement(); // journal3
        writer.WriteEndDocument();
    }

    private void WriteJournalMetadata(XmlWriter writer, Journal journal)
    {
        writer.WriteStartElement("journal");
        
        writer.WriteElementString("titleid", journal.TitleId.ToString());
        
        if (!string.IsNullOrEmpty(journal.Issn))
        {
            writer.WriteElementString("issn", journal.Issn);
        }
        
        if (!string.IsNullOrEmpty(journal.Eissn))
        {
            writer.WriteElementString("eissn", journal.Eissn);
        }
        
        if (journal.JournalInfo != null)
        {
            writer.WriteStartElement("title");
            if (!string.IsNullOrEmpty(journal.JournalInfo.Lang))
            {
                writer.WriteAttributeString("lang", journal.JournalInfo.Lang);
            }
            writer.WriteString(journal.JournalInfo.Title);
            writer.WriteEndElement(); // title
        }
        
        writer.WriteEndElement(); // journal
    }

    private void WriteIssueMetadata(XmlWriter writer, Issue issue)
    {
        writer.WriteStartElement("issue");
        
        if (issue.Volume > 0)
        {
            writer.WriteElementString("volume", issue.Volume.ToString());
        }
        
        if (!string.IsNullOrEmpty(issue.Number))
        {
            writer.WriteElementString("number", issue.Number);
        }
        
        if (!string.IsNullOrEmpty(issue.AltNumber))
        {
            writer.WriteElementString("altNumber", issue.AltNumber);
        }
        
        if (issue.Part > 0)
        {
            writer.WriteElementString("part", issue.Part.ToString());
        }
        
        if (!string.IsNullOrEmpty(issue.Pages))
        {
            writer.WriteElementString("pages", issue.Pages);
        }
        
        writer.WriteElementString("year", issue.DateUni.ToString());
        
        if (issue.IssTitle != null)
        {
            writer.WriteStartElement("issueTitle");
            if (!string.IsNullOrEmpty(issue.IssTitle.Lang))
            {
                writer.WriteAttributeString("lang", issue.IssTitle.Lang);
            }
            writer.WriteString(issue.IssTitle.Value);
            writer.WriteEndElement(); // issueTitle
        }
        
        if (issue.Codes != null)
        {
            writer.WriteStartElement("issueCodes");
            if (!string.IsNullOrEmpty(issue.Codes.Doi))
            {
                writer.WriteElementString("doi", issue.Codes.Doi);
            }
            if (!string.IsNullOrEmpty(issue.Codes.Edn))
            {
                writer.WriteElementString("edn", issue.Codes.Edn);
            }
            writer.WriteEndElement(); // issueCodes
        }
        
        writer.WriteEndElement(); // issue
    }

    private void WriteArticles(XmlWriter writer, Articles articles)
    {
        writer.WriteStartElement("articles");
        
        foreach (var article in articles.ArticleList)
        {
            WriteArticle(writer, article);
        }
        
        writer.WriteEndElement(); // articles
    }

    private void WriteArticle(XmlWriter writer, Article article)
    {
        writer.WriteStartElement("article");
        
        // Article type
        writer.WriteElementString("type", article.ArtType);
        
        // Pages
        writer.WriteElementString("pages", article.Pages);
        
        // Language
        if (!string.IsNullOrEmpty(article.LangPubl))
        {
            writer.WriteElementString("language", article.LangPubl);
        }
        
        // Titles
        writer.WriteStartElement("titles");
        foreach (var title in article.ArtTitles.TitleList)
        {
            writer.WriteStartElement("title");
            writer.WriteAttributeString("lang", title.Lang);
            writer.WriteString(title.Value);
            writer.WriteEndElement(); // title
        }
        writer.WriteEndElement(); // titles
        
        // Abstracts
        if (article.Abstracts != null && article.Abstracts.AbstractList.Any())
        {
            writer.WriteStartElement("abstracts");
            foreach (var abs in article.Abstracts.AbstractList)
            {
                writer.WriteStartElement("abstract");
                writer.WriteAttributeString("lang", abs.Lang);
                writer.WriteString(abs.Value);
                writer.WriteEndElement(); // abstract
            }
            writer.WriteEndElement(); // abstracts
        }
        
        // Authors
        WriteAuthors(writer, article.Authors);
        
        // Codes
        if (article.Codes != null)
        {
            WriteCodes(writer, article.Codes);
        }
        
        // Keywords
        if (article.Keywords != null && article.Keywords.KwdGroupList.Any())
        {
            writer.WriteStartElement("keywords");
            foreach (var kwdGroup in article.Keywords.KwdGroupList)
            {
                writer.WriteStartElement("keywordGroup");
                writer.WriteAttributeString("lang", kwdGroup.Lang);
                foreach (var keyword in kwdGroup.KeywordList)
                {
                    writer.WriteElementString("keyword", keyword);
                }
                writer.WriteEndElement(); // keywordGroup
            }
            writer.WriteEndElement(); // keywords
        }
        
        // Full text
        if (article.Texts.Any())
        {
            writer.WriteStartElement("fullText");
            foreach (var text in article.Texts)
            {
                writer.WriteStartElement("text");
                if (!string.IsNullOrEmpty(text.Lang))
                {
                    writer.WriteAttributeString("lang", text.Lang);
                }
                writer.WriteString(text.Value);
                writer.WriteEndElement(); // text
            }
            writer.WriteEndElement(); // fullText
        }
        
        // References
        if (article.References != null && article.References.ReferenceList.Any())
        {
            writer.WriteStartElement("references");
            foreach (var reference in article.References.ReferenceList)
            {
                writer.WriteStartElement("reference");
                // Get first refInfo or default
                var refInfo = reference.RefInfoList.FirstOrDefault();
                if (refInfo != null)
                {
                    writer.WriteString(refInfo.Text);
                }
                writer.WriteEndElement(); // reference
            }
            writer.WriteEndElement(); // references
        }
        
        // Dates
        if (article.Dates != null)
        {
            writer.WriteStartElement("dates");
            if (!string.IsNullOrEmpty(article.Dates.DateReceived))
            {
                writer.WriteElementString("received", article.Dates.DateReceived);
            }
            if (!string.IsNullOrEmpty(article.Dates.DateAccepted))
            {
                writer.WriteElementString("accepted", article.Dates.DateAccepted);
            }
            if (!string.IsNullOrEmpty(article.Dates.DatePublication))
            {
                writer.WriteElementString("published", article.Dates.DatePublication);
            }
            writer.WriteEndElement(); // dates
        }
        
        // Funding
        if (article.Fundings != null && article.Fundings.FundingList.Any())
        {
            writer.WriteStartElement("funding");
            foreach (var fund in article.Fundings.FundingList)
            {
                writer.WriteStartElement("grant");
                if (!string.IsNullOrEmpty(fund.Lang))
                {
                    writer.WriteAttributeString("lang", fund.Lang);
                }
                writer.WriteString(fund.Value);
                writer.WriteEndElement(); // grant
            }
            writer.WriteEndElement(); // funding
        }
        
        writer.WriteEndElement(); // article
    }

    private void WriteAuthors(XmlWriter writer, List<Author> authors)
    {
        if (!authors.Any()) return;
        
        writer.WriteStartElement("authors");
        
        foreach (var author in authors)
        {
            writer.WriteStartElement("author");
            writer.WriteAttributeString("num", author.Num.ToString());
            
            if (!string.IsNullOrEmpty(author.Role))
            {
                writer.WriteElementString("role", author.Role);
            }
            
            if (!string.IsNullOrEmpty(author.Correspondent))
            {
                writer.WriteElementString("correspondent", author.Correspondent);
            }
            
            // Author codes
            if (author.AuthorCodes != null)
            {
                writer.WriteStartElement("codes");
                if (!string.IsNullOrEmpty(author.AuthorCodes.Orcid))
                {
                    writer.WriteElementString("orcid", author.AuthorCodes.Orcid);
                }
                if (!string.IsNullOrEmpty(author.AuthorCodes.Spin))
                {
                    writer.WriteElementString("spin", author.AuthorCodes.Spin);
                }
                if (!string.IsNullOrEmpty(author.AuthorCodes.ScopusId))
                {
                    writer.WriteElementString("scopusid", author.AuthorCodes.ScopusId);
                }
                if (!string.IsNullOrEmpty(author.AuthorCodes.ResearcherId))
                {
                    writer.WriteElementString("researcherid", author.AuthorCodes.ResearcherId);
                }
                writer.WriteEndElement(); // codes
            }
            
            // Individual info (multiple languages)
            foreach (var individInfo in author.IndividInfoList)
            {
                writer.WriteStartElement("info");
                writer.WriteAttributeString("lang", individInfo.Lang);
                
                writer.WriteElementString("surname", individInfo.Surname);
                
                if (!string.IsNullOrEmpty(individInfo.Initials))
                {
                    writer.WriteElementString("initials", individInfo.Initials);
                }
                
                if (!string.IsNullOrEmpty(individInfo.OrgName))
                {
                    writer.WriteElementString("organization", individInfo.OrgName);
                }
                
                if (!string.IsNullOrEmpty(individInfo.Email))
                {
                    writer.WriteElementString("email", individInfo.Email);
                }
                
                writer.WriteEndElement(); // info
            }
            
            writer.WriteEndElement(); // author
        }
        
        writer.WriteEndElement(); // authors
    }

    private void WriteCodes(XmlWriter writer, ArticleCodes codes)
    {
        writer.WriteStartElement("codes");
        
        if (!string.IsNullOrEmpty(codes.Doi))
        {
            writer.WriteElementString("doi", codes.Doi);
        }
        
        if (!string.IsNullOrEmpty(codes.Edn))
        {
            writer.WriteElementString("edn", codes.Edn);
        }
        
        if (!string.IsNullOrEmpty(codes.Udk))
        {
            writer.WriteElementString("udk", codes.Udk);
        }
        
        if (!string.IsNullOrEmpty(codes.Bbk))
        {
            writer.WriteElementString("bbk", codes.Bbk);
        }
        
        if (!string.IsNullOrEmpty(codes.Vak))
        {
            writer.WriteElementString("vak", codes.Vak);
        }
        
        if (!string.IsNullOrEmpty(codes.Jel))
        {
            writer.WriteElementString("jel", codes.Jel);
        }
        
        if (!string.IsNullOrEmpty(codes.Msc))
        {
            writer.WriteElementString("msc", codes.Msc);
        }
        
        if (!string.IsNullOrEmpty(codes.Pacs))
        {
            writer.WriteElementString("pacs", codes.Pacs);
        }
        
        writer.WriteEndElement(); // codes
    }
}
