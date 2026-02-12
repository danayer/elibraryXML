using elibraryXMLApp.Models;

namespace elibraryXMLApp.Services;

/// <summary>
/// Interface for XML serialization and validation services
/// </summary>
public interface IXmlService
{
    /// <summary>
    /// Save journal data to XML file
    /// </summary>
    void SaveJournalToXml(Journal journal, string filePath);

    /// <summary>
    /// Load journal data from XML file
    /// </summary>
    Journal? LoadJournalFromXml(string filePath);

    /// <summary>
    /// Validate XML file against XSD schema
    /// </summary>
    bool ValidateXml(string xmlFilePath, string xsdFilePath);
}
