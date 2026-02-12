using elibraryXMLApp.Models;

namespace elibraryXMLApp.Services;

/// <summary>
/// Interface for exporting to journal3 XML format (for "Metaphor" IS)
/// </summary>
public interface IJournal3ExportService
{
    /// <summary>
    /// Export entire journal to journal3 XML format
    /// </summary>
    void ExportToJournal3(Journal journal, string filePath);
}
