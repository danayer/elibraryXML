using elibraryXMLApp.Models;

namespace elibraryXMLApp.Services;

/// <summary>
/// Interface for parsing HTML files and extracting article metadata
/// </summary>
public interface IHtmlParsingService
{
    /// <summary>
    /// Parse HTML file and create a Journal with extracted articles
    /// </summary>
    Journal ParseHtmlFile(string htmlFilePath);

    /// <summary>
    /// Parse HTML content and create a Journal with extracted articles
    /// </summary>
    Journal ParseHtmlContent(string htmlContent);
}
