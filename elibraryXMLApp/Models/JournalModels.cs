using System.Xml.Serialization;

namespace elibraryXMLApp.Models;

[XmlRoot("journal")]
public class Journal
{
    [XmlElement("titleid")]
    public uint TitleId { get; set; }

    [XmlElement("issn")]
    public string? Issn { get; set; }

    [XmlElement("eissn")]
    public string? Eissn { get; set; }

    [XmlElement("journalInfo")]
    public JournalInfo JournalInfo { get; set; } = new JournalInfo();

    [XmlElement("issue")]
    public Issue Issue { get; set; } = new Issue();
}

public class JournalInfo
{
    [XmlElement("title")]
    public string Title { get; set; } = string.Empty;

    [XmlAttribute("lang")]
    public string? Lang { get; set; }
}

public class Issue
{
    [XmlAttribute("type")]
    public string? Type { get; set; }

    [XmlElement("volume")]
    public uint Volume { get; set; }

    [XmlElement("number")]
    public string? Number { get; set; }

    [XmlElement("altNumber")]
    public string? AltNumber { get; set; }

    [XmlElement("part")]
    public ushort Part { get; set; }

    [XmlElement("pages")]
    public string? Pages { get; set; }

    [XmlElement("dateUni")]
    public ushort DateUni { get; set; }

    [XmlElement("issTitle")]
    public IssTitle? IssTitle { get; set; }

    [XmlElement("codes")]
    public IssueCodes? Codes { get; set; }

    [XmlElement("articles")]
    public Articles Articles { get; set; } = new Articles();
}

public class IssTitle
{
    [XmlAttribute("lang")]
    public string? Lang { get; set; }

    [XmlText]
    public string Value { get; set; } = string.Empty;
}

public class IssueCodes
{
    [XmlElement("doi")]
    public string? Doi { get; set; }

    [XmlElement("edn")]
    public string? Edn { get; set; }
}

public class Articles
{
    [XmlElement("article")]
    public List<Article> ArticleList { get; set; } = new List<Article>();
}

public class Article
{
    [XmlElement("artType")]
    public string ArtType { get; set; } = "RAR";

    [XmlElement("pages")]
    public string Pages { get; set; } = string.Empty;

    [XmlElement("langPubl")]
    public string? LangPubl { get; set; }

    [XmlArray("authors")]
    [XmlArrayItem("author")]
    public List<Author> Authors { get; set; } = new List<Author>();

    [XmlElement("artTitles")]
    public ArtTitles ArtTitles { get; set; } = new ArtTitles();

    [XmlElement("abstracts")]
    public Abstracts? Abstracts { get; set; }

    // КРИТИЧЕСКИ ВАЖНО: обязательный элемент согласно XSD!
    // CRITICAL: required element according to XSD!
    [XmlElement("text")]
    public List<ArticleText> Texts { get; set; } = new List<ArticleText>();

    [XmlElement("codes")]
    public ArticleCodes? Codes { get; set; }

    [XmlElement("keywords")]
    public Keywords? Keywords { get; set; }

    [XmlElement("references")]
    public References? References { get; set; }

    [XmlElement("files")]
    public Files? Files { get; set; }

    [XmlElement("dates")]
    public ArticleDates? Dates { get; set; }

    [XmlElement("fundings")]
    public Fundings? Fundings { get; set; }

    [XmlElement("rubrics")]
    public Rubrics? Rubrics { get; set; }
}

public class Author
{
    // КРИТИЧЕСКИ ВАЖНО: обязательный атрибут согласно XSD!
    // CRITICAL: required attribute according to XSD!
    [XmlAttribute("num")]
    public uint Num { get; set; } = 1;

    [XmlElement("role")]
    public string? Role { get; set; }

    [XmlElement("correspondent")]
    public string? Correspondent { get; set; }

    [XmlElement("authorCodes")]
    public AuthorCodes? AuthorCodes { get; set; }

    // КРИТИЧЕСКИ ВАЖНО: XSD позволяет 1-3 элемента individInfo (разные языки)!
    // CRITICAL: XSD allows 1-3 individInfo elements (different languages)!
    [XmlElement("individInfo")]
    public List<IndividInfo> IndividInfoList { get; set; } = new List<IndividInfo>();
}

public class IndividInfo
{
    // КРИТИЧЕСКИ ВАЖНО: обязательный атрибут согласно XSD!
    // CRITICAL: required attribute according to XSD!
    [XmlAttribute("lang")]
    public string Lang { get; set; } = "RUS";

    [XmlElement("surname")]
    public string Surname { get; set; } = string.Empty;

    [XmlElement("initials")]
    public string? Initials { get; set; }

    [XmlElement("orgName")]
    public string? OrgName { get; set; }

    [XmlElement("email")]
    public string? Email { get; set; }
}

public class ArtTitles
{
    [XmlElement("artTitle")]
    public List<ArtTitle> TitleList { get; set; } = new List<ArtTitle>();
}

public class ArtTitle
{
    [XmlAttribute("lang")]
    public string Lang { get; set; } = "RUS";

    [XmlText]
    public string Value { get; set; } = string.Empty;
}

public class Abstracts
{
    [XmlElement("abstract")]
    public List<Abstract> AbstractList { get; set; } = new List<Abstract>();
}

public class Abstract
{
    [XmlAttribute("lang")]
    public string Lang { get; set; } = "RUS";

    [XmlText]
    public string Value { get; set; } = string.Empty;
}

public class Keywords
{
    [XmlElement("kwdGroup")]
    public List<KwdGroup> KwdGroupList { get; set; } = new List<KwdGroup>();
}

public class KwdGroup
{
    [XmlAttribute("lang")]
    public string Lang { get; set; } = "RUS";

    [XmlElement("keyword")]
    public List<string> KeywordList { get; set; } = new List<string>();
}

public class ArticleCodes
{
    [XmlElement("doi")]
    public string? Doi { get; set; }

    [XmlElement("edn")]
    public string? Edn { get; set; }

    [XmlElement("udk")]
    public string? Udk { get; set; }

    [XmlElement("bbk")]
    public string? Bbk { get; set; }

    [XmlElement("vak")]
    public string? Vak { get; set; }

    [XmlElement("jel")]
    public string? Jel { get; set; }

    [XmlElement("msc")]
    public string? Msc { get; set; }

    [XmlElement("pacs")]
    public string? Pacs { get; set; }
}

public class References
{
    [XmlElement("reference")]
    public List<Reference> ReferenceList { get; set; } = new List<Reference>();
}

public class Reference
{
    [XmlElement("refInfo")]
    public List<RefInfo> RefInfoList { get; set; } = new List<RefInfo>();
}

public class RefInfo
{
    [XmlAttribute("lang")]
    public string? Lang { get; set; }

    [XmlElement("text")]
    public string Text { get; set; } = string.Empty;
}

public class Files
{
    [XmlElement("file")]
    public List<FileItem> FileList { get; set; } = new List<FileItem>();
    
    [XmlElement("furl")]
    public List<FileUrl> UrlList { get; set; } = new List<FileUrl>();
}

public class FileItem
{
    [XmlAttribute("desc")]
    public string? Desc { get; set; }
    
    [XmlAttribute("lang")]
    public string? Lang { get; set; }
    
    [XmlText]
    public string Value { get; set; } = string.Empty;
}

public class FileUrl
{
    [XmlAttribute("desc")]
    public string? Desc { get; set; }
    
    [XmlAttribute("lang")]
    public string? Lang { get; set; }
    
    [XmlText]
    public string Value { get; set; } = string.Empty;
}

// New classes for enhanced functionality

public class ArticleText
{
    [XmlAttribute("lang")]
    public string? Lang { get; set; }

    [XmlText]
    public string Value { get; set; } = string.Empty;
}

public class AuthorCodes
{
    [XmlElement("researcherid")]
    public string? ResearcherId { get; set; }

    [XmlElement("spin")]
    public string? Spin { get; set; }

    [XmlElement("scopusid")]
    public string? ScopusId { get; set; }

    [XmlElement("orcid")]
    public string? Orcid { get; set; }
}

public class ArticleDates
{
    [XmlElement("dateReceived")]
    public string? DateReceived { get; set; }

    [XmlElement("dateAccepted")]
    public string? DateAccepted { get; set; }

    [XmlElement("datePublication")]
    public string? DatePublication { get; set; }
}

public class Fundings
{
    [XmlElement("funding")]
    public List<Funding> FundingList { get; set; } = new List<Funding>();
}

public class Funding
{
    [XmlAttribute("lang")]
    public string? Lang { get; set; }

    [XmlText]
    public string Value { get; set; } = string.Empty;
}

public class Rubrics
{
    [XmlElement("rubric")]
    public List<string> RubricList { get; set; } = new List<string>();
}

// URL Description Type (typeUrlDesc from XSD)
public enum UrlDescType
{
    // Ссылка на полный текст публикации в формате PDF
    FullText,
    // Ссылка на описание публикации
    Description,
    // Ссылка на препринт
    Preprint,
    // Ссылка на версию на другом языке
    VersionAnotherLanguage,
    // Ссылка на другое издание
    AnotherEdition,
    // Ссылка на продолжение
    Continuation,
    // Ссылка на начало
    Beginning,
    // Ссылка на приложение
    Application,
    // Ссылка на исправление
    Correction,
    // Ссылка на дополнение
    Addition,
    // Ссылка на рецензию
    Review,
    // Ссылка на комментарий
    Comment,
    // Ссылка на медиафайл
    MediaFile,
    // Ссылка на презентацию
    Presentation,
    // Ссылка на данные
    Data,
    // Ссылка на дополнительные материалы
    AdditionalMaterials,
    // Другое
    Other
}

// Helper class for URL description type conversions
public static class UrlDescTypeHelper
{
    // Convert enum to XSD string value (camelCase)
    public static string ToXsdValue(UrlDescType type)
    {
        return type switch
        {
            UrlDescType.FullText => "fullText",
            UrlDescType.Description => "description",
            UrlDescType.Preprint => "preprint",
            UrlDescType.VersionAnotherLanguage => "versionAnotherLanguage",
            UrlDescType.AnotherEdition => "anotherEdition",
            UrlDescType.Continuation => "continuation",
            UrlDescType.Beginning => "beginning",
            UrlDescType.Application => "application",
            UrlDescType.Correction => "correction",
            UrlDescType.Addition => "addition",
            UrlDescType.Review => "review",
            UrlDescType.Comment => "comment",
            UrlDescType.MediaFile => "mediaFile",
            UrlDescType.Presentation => "presentation",
            UrlDescType.Data => "data",
            UrlDescType.AdditionalMaterials => "additionalMaterials",
            UrlDescType.Other => "other",
            _ => "other"
        };
    }
    
    // Convert XSD string value to enum
    public static UrlDescType? FromXsdValue(string? value)
    {
        if (string.IsNullOrEmpty(value)) return null;
        
        return value switch
        {
            "fullText" => UrlDescType.FullText,
            "description" => UrlDescType.Description,
            "preprint" => UrlDescType.Preprint,
            "versionAnotherLanguage" => UrlDescType.VersionAnotherLanguage,
            "anotherEdition" => UrlDescType.AnotherEdition,
            "continuation" => UrlDescType.Continuation,
            "beginning" => UrlDescType.Beginning,
            "application" => UrlDescType.Application,
            "correction" => UrlDescType.Correction,
            "addition" => UrlDescType.Addition,
            "review" => UrlDescType.Review,
            "comment" => UrlDescType.Comment,
            "mediaFile" => UrlDescType.MediaFile,
            "presentation" => UrlDescType.Presentation,
            "data" => UrlDescType.Data,
            "additionalMaterials" => UrlDescType.AdditionalMaterials,
            "other" => UrlDescType.Other,
            _ => null
        };
    }
    
    // Get display name with Russian and English text
    public static string GetDisplayName(UrlDescType type)
    {
        return type switch
        {
            UrlDescType.FullText => "Полный текст / Full Text",
            UrlDescType.Description => "Описание / Description",
            UrlDescType.Preprint => "Препринт / Preprint",
            UrlDescType.VersionAnotherLanguage => "Версия на другом языке / Another Language Version",
            UrlDescType.AnotherEdition => "Другое издание / Another Edition",
            UrlDescType.Continuation => "Продолжение / Continuation",
            UrlDescType.Beginning => "Начало / Beginning",
            UrlDescType.Application => "Приложение / Application",
            UrlDescType.Correction => "Исправление / Correction",
            UrlDescType.Addition => "Дополнение / Addition",
            UrlDescType.Review => "Рецензия / Review",
            UrlDescType.Comment => "Комментарий / Comment",
            UrlDescType.MediaFile => "Медиафайл / Media File",
            UrlDescType.Presentation => "Презентация / Presentation",
            UrlDescType.Data => "Данные / Data",
            UrlDescType.AdditionalMaterials => "Дополнительные материалы / Additional Materials",
            UrlDescType.Other => "Другое / Other",
            _ => "Другое / Other"
        };
    }
    
    // Get all types for UI selection
    public static List<UrlDescType> GetAllTypes()
    {
        return new List<UrlDescType>
        {
            UrlDescType.FullText,
            UrlDescType.Description,
            UrlDescType.Preprint,
            UrlDescType.VersionAnotherLanguage,
            UrlDescType.AnotherEdition,
            UrlDescType.Continuation,
            UrlDescType.Beginning,
            UrlDescType.Application,
            UrlDescType.Correction,
            UrlDescType.Addition,
            UrlDescType.Review,
            UrlDescType.Comment,
            UrlDescType.MediaFile,
            UrlDescType.Presentation,
            UrlDescType.Data,
            UrlDescType.AdditionalMaterials,
            UrlDescType.Other
        };
    }
}
