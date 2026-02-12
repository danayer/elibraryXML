using System.Text;
using System.Xml;
using System.Xml.Serialization;
using elibraryXMLApp.Models;

namespace elibraryXMLApp.Services;

public class XmlService : IXmlService
{
    public void SaveJournalToXml(Journal journal, string filePath)
    {
        var serializer = new XmlSerializer(typeof(Journal));
        var settings = new XmlWriterSettings
        {
            Indent = true,
            IndentChars = "  ",
            Encoding = Encoding.UTF8,
            OmitXmlDeclaration = false
        };

        using var writer = XmlWriter.Create(filePath, settings);
        serializer.Serialize(writer, journal);
    }

    public Journal? LoadJournalFromXml(string filePath)
    {
        var serializer = new XmlSerializer(typeof(Journal));
        using var reader = XmlReader.Create(filePath);
        return serializer.Deserialize(reader) as Journal;
    }

    public bool ValidateXml(string xmlFilePath, string xsdFilePath)
    {
        try
        {
            var settings = new XmlReaderSettings();
            settings.Schemas.Add(null, xsdFilePath);
            settings.ValidationType = ValidationType.Schema;

            bool isValid = true;
            settings.ValidationEventHandler += (sender, args) =>
            {
                isValid = false;
                System.Diagnostics.Debug.WriteLine($"Validation error: {args.Message}");
            };

            using var reader = XmlReader.Create(xmlFilePath, settings);
            while (reader.Read()) { }

            return isValid;
        }
        catch (XmlException ex)
        {
            System.Diagnostics.Debug.WriteLine($"XML parsing error: {ex.Message}");
            return false;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Validation error: {ex.Message}");
            return false;
        }
    }
}
