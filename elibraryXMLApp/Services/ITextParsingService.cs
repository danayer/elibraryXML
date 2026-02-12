namespace elibraryXMLApp.Services;

/// <summary>
/// Interface for manual text parsing and metadata extraction
/// </summary>
public interface ITextParsingService
{
    /// <summary>
    /// Parse text and extract article metadata
    /// </summary>
    ParsedArticleData ParseArticleText(string sourceText);
}
