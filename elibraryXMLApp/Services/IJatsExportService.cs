using elibraryXMLApp.Models;

namespace elibraryXMLApp.Services;

/// <summary>
/// Interface for exporting to JATS XML format (NISO Z39.96 standard)
/// </summary>
public interface IJatsExportService
{
    /// <summary>
    /// Export all articles to JATS XML format (one file per article)
    /// </summary>
    void ExportToJats(Journal journal, string outputDirectory);
}
