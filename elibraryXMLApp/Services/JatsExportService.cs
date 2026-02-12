using System.Text;
using System.Xml;
using elibraryXMLApp.Models;

namespace elibraryXMLApp.Services;

/// <summary>
/// Service for exporting to JATS XML format (NISO Z39.96 standard)
/// Each article is exported as a separate file
/// </summary>
public class JatsExportService : IJatsExportService
{
    /// <summary>
    /// Export all articles to JATS XML format (one file per article)
    /// </summary>
    public void ExportToJats(Journal journal, string outputDirectory)
    {
        Directory.CreateDirectory(outputDirectory);
        
        int articleIndex = 1;
        foreach (var article in journal.Issue.Articles.ArticleList)
        {
            var fileName = $"article_{articleIndex:D3}.xml";
            var filePath = Path.Combine(outputDirectory, fileName);
            ExportArticleToJats(article, journal, filePath);
            articleIndex++;
        }
    }

    private void ExportArticleToJats(Article article, Journal journal, string filePath)
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
        writer.WriteDocType("article", "-//NLM//DTD JATS (Z39.96) Journal Publishing DTD v1.2 20190208//EN", 
            "JATS-journalpublishing1.dtd", null);
        
        // Start article element
        writer.WriteStartElement("article");
        writer.WriteAttributeString("xmlns", "xlink", null, "http://www.w3.org/1999/xlink");
        writer.WriteAttributeString("article-type", "research-article");
        writer.WriteAttributeString("xml", "lang", null, article.LangPubl ?? "ru");
        
        // Front matter
        WriteFrontMatter(writer, article, journal);
        
        // Body (article text)
        WriteBody(writer, article);
        
        // Back matter (references)
        WriteBackMatter(writer, article);
        
        writer.WriteEndElement(); // article
        writer.WriteEndDocument();
    }

    private void WriteFrontMatter(XmlWriter writer, Article article, Journal journal)
    {
        writer.WriteStartElement("front");
        
        // Journal metadata
        writer.WriteStartElement("journal-meta");
        
        if (!string.IsNullOrEmpty(journal.Issn))
        {
            writer.WriteStartElement("issn");
            writer.WriteAttributeString("pub-type", "print");
            writer.WriteString(journal.Issn);
            writer.WriteEndElement();
        }
        
        if (!string.IsNullOrEmpty(journal.Eissn))
        {
            writer.WriteStartElement("issn");
            writer.WriteAttributeString("pub-type", "electronic");
            writer.WriteString(journal.Eissn);
            writer.WriteEndElement();
        }
        
        writer.WriteStartElement("journal-title-group");
        writer.WriteElementString("journal-title", journal.JournalInfo?.Title ?? "");
        writer.WriteEndElement(); // journal-title-group
        
        writer.WriteEndElement(); // journal-meta
        
        // Article metadata
        writer.WriteStartElement("article-meta");
        
        // Article IDs
        if (!string.IsNullOrEmpty(article.Codes?.Doi))
        {
            writer.WriteStartElement("article-id");
            writer.WriteAttributeString("pub-id-type", "doi");
            writer.WriteString(article.Codes.Doi);
            writer.WriteEndElement();
        }
        
        // Title group
        writer.WriteStartElement("title-group");
        foreach (var title in article.ArtTitles.TitleList)
        {
            writer.WriteStartElement("article-title");
            writer.WriteAttributeString("xml", "lang", null, title.Lang.ToLower());
            writer.WriteString(title.Value);
            writer.WriteEndElement();
        }
        writer.WriteEndElement(); // title-group
        
        // Contributors (authors)
        if (article.Authors.Any())
        {
            writer.WriteStartElement("contrib-group");
            foreach (var author in article.Authors)
            {
                WriteContributor(writer, author);
            }
            writer.WriteEndElement(); // contrib-group
        }
        
        // Publication date
        if (article.Dates?.DatePublication != null)
        {
            writer.WriteStartElement("pub-date");
            writer.WriteAttributeString("pub-type", "epub");
            writer.WriteElementString("string-date", article.Dates.DatePublication);
            writer.WriteEndElement();
        }
        
        // Volume and issue
        if (journal.Issue.Volume > 0)
        {
            writer.WriteElementString("volume", journal.Issue.Volume.ToString());
        }
        if (!string.IsNullOrEmpty(journal.Issue.Number))
        {
            writer.WriteElementString("issue", journal.Issue.Number);
        }
        
        // Pages
        if (!string.IsNullOrEmpty(article.Pages))
        {
            var pages = article.Pages.Split('-', '–');
            if (pages.Length == 2)
            {
                writer.WriteElementString("fpage", pages[0].Trim());
                writer.WriteElementString("lpage", pages[1].Trim());
            }
        }
        
        // Abstract
        if (article.Abstracts != null)
        {
            foreach (var abs in article.Abstracts.AbstractList)
            {
                writer.WriteStartElement("abstract");
                writer.WriteAttributeString("xml", "lang", null, abs.Lang.ToLower());
                writer.WriteStartElement("p");
                writer.WriteString(abs.Value);
                writer.WriteEndElement(); // p
                writer.WriteEndElement(); // abstract
            }
        }
        
        // Keywords
        if (article.Keywords != null)
        {
            foreach (var kwdGroup in article.Keywords.KwdGroupList)
            {
                writer.WriteStartElement("kwd-group");
                writer.WriteAttributeString("xml", "lang", null, kwdGroup.Lang.ToLower());
                foreach (var keyword in kwdGroup.KeywordList)
                {
                    writer.WriteElementString("kwd", keyword);
                }
                writer.WriteEndElement(); // kwd-group
            }
        }
        
        writer.WriteEndElement(); // article-meta
        writer.WriteEndElement(); // front
    }

    private void WriteContributor(XmlWriter writer, Author author)
    {
        writer.WriteStartElement("contrib");
        writer.WriteAttributeString("contrib-type", "author");
        
        // Use first individInfo (usually Russian)
        var individInfo = author.IndividInfoList.FirstOrDefault();
        if (individInfo != null)
        {
            writer.WriteStartElement("name");
            writer.WriteElementString("surname", individInfo.Surname);
            if (!string.IsNullOrEmpty(individInfo.Initials))
            {
                writer.WriteElementString("given-names", individInfo.Initials);
            }
            writer.WriteEndElement(); // name
            
            // Affiliation
            if (!string.IsNullOrEmpty(individInfo.OrgName))
            {
                writer.WriteStartElement("aff");
                writer.WriteString(individInfo.OrgName);
                writer.WriteEndElement();
            }
            
            // Email
            if (!string.IsNullOrEmpty(individInfo.Email))
            {
                writer.WriteElementString("email", individInfo.Email);
            }
        }
        
        // ORCID
        if (!string.IsNullOrEmpty(author.AuthorCodes?.Orcid))
        {
            writer.WriteStartElement("contrib-id");
            writer.WriteAttributeString("contrib-id-type", "orcid");
            writer.WriteString(author.AuthorCodes.Orcid);
            writer.WriteEndElement();
        }
        
        writer.WriteEndElement(); // contrib
    }

    private void WriteBody(XmlWriter writer, Article article)
    {
        if (article.Texts.Any())
        {
            writer.WriteStartElement("body");
            writer.WriteStartElement("sec");
            foreach (var text in article.Texts)
            {
                writer.WriteStartElement("p");
                writer.WriteString(text.Value);
                writer.WriteEndElement(); // p
            }
            writer.WriteEndElement(); // sec
            writer.WriteEndElement(); // body
        }
    }

    private void WriteBackMatter(XmlWriter writer, Article article)
    {
        if (article.References != null && article.References.ReferenceList.Any())
        {
            writer.WriteStartElement("back");
            writer.WriteStartElement("ref-list");
            
            int refNum = 1;
            foreach (var reference in article.References.ReferenceList)
            {
                writer.WriteStartElement("ref");
                writer.WriteAttributeString("id", $"ref{refNum}");
                writer.WriteStartElement("mixed-citation");
                // Get first refInfo or default
                var refInfo = reference.RefInfoList.FirstOrDefault();
                if (refInfo != null)
                {
                    writer.WriteString(refInfo.Text);
                }
                writer.WriteEndElement(); // mixed-citation
                writer.WriteEndElement(); // ref
                refNum++;
            }
            
            writer.WriteEndElement(); // ref-list
            writer.WriteEndElement(); // back
        }
    }
}
