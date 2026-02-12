using elibraryXMLApp.Models;

namespace elibraryXMLApp.Services;

/// <summary>
/// Interface for JSON serialization and backup/restore functionality
/// </summary>
public interface IJsonService
{
    /// <summary>
    /// Save journal data to JSON backup file
    /// </summary>
    void SaveJournalToJson(Journal journal, string filePath);

    /// <summary>
    /// Load journal data from JSON backup file
    /// </summary>
    Journal? LoadJournalFromJson(string filePath);

    /// <summary>
    /// Auto-save to temporary JSON file
    /// </summary>
    void AutoSave(Journal journal, string autoSaveDir = "");

    /// <summary>
    /// Try to restore from auto-save file
    /// </summary>
    Journal? TryRestoreAutoSave(string autoSaveDir = "");
}
