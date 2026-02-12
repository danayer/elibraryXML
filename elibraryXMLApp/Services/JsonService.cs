using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using elibraryXMLApp.Models;

namespace elibraryXMLApp.Services;

/// <summary>
/// Service for JSON serialization and backup/restore functionality
/// </summary>
public class JsonService : IJsonService
{
    private readonly JsonSerializerOptions _options;

    public JsonService()
    {
        _options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    /// <summary>
    /// Save journal data to JSON backup file
    /// </summary>
    public void SaveJournalToJson(Journal journal, string filePath)
    {
        var json = JsonSerializer.Serialize(journal, _options);
        File.WriteAllText(filePath, json);
    }

    /// <summary>
    /// Load journal data from JSON backup file
    /// </summary>
    public Journal? LoadJournalFromJson(string filePath)
    {
        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<Journal>(json, _options);
    }

    /// <summary>
    /// Auto-save to temporary JSON file
    /// </summary>
    public void AutoSave(Journal journal, string autoSaveDir = "")
    {
        if (string.IsNullOrEmpty(autoSaveDir))
        {
            autoSaveDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "elibraryXMLApp"
            );
        }

        Directory.CreateDirectory(autoSaveDir);
        var autoSaveFile = Path.Combine(autoSaveDir, "autosave.json");
        
        try
        {
            SaveJournalToJson(journal, autoSaveFile);
        }
        catch
        {
            // Silent fail for auto-save
        }
    }

    /// <summary>
    /// Try to restore from auto-save file
    /// </summary>
    public Journal? TryRestoreAutoSave(string autoSaveDir = "")
    {
        if (string.IsNullOrEmpty(autoSaveDir))
        {
            autoSaveDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "elibraryXMLApp"
            );
        }

        var autoSaveFile = Path.Combine(autoSaveDir, "autosave.json");
        
        if (File.Exists(autoSaveFile))
        {
            try
            {
                return LoadJournalFromJson(autoSaveFile);
            }
            catch
            {
                return null;
            }
        }

        return null;
    }
}
