using System.Drawing;
using System.Drawing.Imaging;
using elibraryXMLApp.Models;

namespace elibraryXMLApp.Services;

/// <summary>
/// Service for building issue archives with all required files
/// </summary>
public class ArchiveBuilderService : IArchiveBuilderService
{
    private readonly IXmlService xmlService;

    public ArchiveBuilderService(IXmlService xmlService)
    {
        this.xmlService = xmlService;
    }

    /// <summary>
    /// Validate and build archive structure
    /// </summary>
    public ArchiveBuilderResult BuildArchive(Journal journal, ArchiveBuilderSettings settings)
    {
        var result = new ArchiveBuilderResult();

        try
        {
            // Create output directory structure
            Directory.CreateDirectory(settings.OutputDirectory);

            var coverDir = Path.Combine(settings.OutputDirectory, "cover");
            var articlesDir = Path.Combine(settings.OutputDirectory, "articles");
            var metadataDir = Path.Combine(settings.OutputDirectory, "metadata");

            Directory.CreateDirectory(coverDir);
            Directory.CreateDirectory(articlesDir);
            Directory.CreateDirectory(metadataDir);

            // 1. Process cover images (legacy support for single cover)
            if (!string.IsNullOrEmpty(settings.CoverImagePath))
            {
                var coverResult = ProcessCoverImage(settings.CoverImagePath, coverDir, "cover.jpg");
                result.CoverImageProcessed = coverResult.Success;
                result.Messages.Add(coverResult.Message);
            }

            // 1a. Process Russian cover image
            if (!string.IsNullOrEmpty(settings.CoverImageRussianPath))
            {
                var coverResult = ProcessCoverImage(settings.CoverImageRussianPath, coverDir, "cover_ru.jpg");
                result.CoverImageRussianProcessed = coverResult.Success;
                result.Messages.Add(coverResult.Message);
            }

            // 1b. Process English cover image
            if (!string.IsNullOrEmpty(settings.CoverImageEnglishPath))
            {
                var coverResult = ProcessCoverImage(settings.CoverImageEnglishPath, coverDir, "cover_en.jpg");
                result.CoverImageEnglishProcessed = coverResult.Success;
                result.Messages.Add(coverResult.Message);
            }

            // 2. Copy/validate article PDFs
            if (settings.ArticlePdfPaths != null && settings.ArticlePdfPaths.Any())
            {
                foreach (var pdfPath in settings.ArticlePdfPaths)
                {
                    var pdfResult = ProcessArticlePdf(pdfPath, articlesDir);
                    result.ArticlePdfsProcessed += pdfResult.Success ? 1 : 0;
                    result.Messages.Add(pdfResult.Message);
                }
            }

            // 3. Copy combined PDF
            if (!string.IsNullOrEmpty(settings.CombinedPdfPath))
            {
                var combinedResult = ProcessCombinedPdf(settings.CombinedPdfPath, settings.OutputDirectory);
                result.CombinedPdfProcessed = combinedResult.Success;
                result.Messages.Add(combinedResult.Message);
            }

            // 4. Process XML metadata
            string xmlPath;
            if (!string.IsNullOrEmpty(settings.XmlMetadataPath))
            {
                // Use attached XML file
                xmlPath = Path.Combine(metadataDir, "journal.xml");
                File.Copy(settings.XmlMetadataPath, xmlPath, true);
                result.XmlMetadataAttached = true;
                result.Messages.Add($"✓ XML метаданные скопированы: {xmlPath}");
            }
            else
            {
                // Generate XML metadata
                xmlPath = Path.Combine(metadataDir, "journal.xml");
                xmlService.SaveJournalToXml(journal, xmlPath);
                result.XmlMetadataGenerated = true;
                result.Messages.Add($"✓ XML метаданные сгенерированы: {xmlPath}");
            }

            // 5. Verify file names against XML content
            result.Messages.Add("\n=== Верификация файлов ===");
            var verificationResult = VerifyFilesAgainstXml(journal, settings, articlesDir);
            result.VerificationPassed = verificationResult.Success;
            result.VerificationErrors = verificationResult.Errors;
            result.Messages.AddRange(verificationResult.Messages);

            result.Success = true;
            result.Messages.Add($"\n✓ Архив выпуска успешно подготовлен в: {settings.OutputDirectory}");
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Messages.Add($"✗ Ошибка: {ex.Message}");
        }

        return result;
    }

    private ProcessingResult ProcessCoverImage(string sourcePath, string outputDir, string outputFileName = "cover.jpg")
    {
        try
        {
            if (!File.Exists(sourcePath))
            {
                return new ProcessingResult { Success = false, Message = $"✗ Файл обложки не найден: {sourcePath}" };
            }

            // Load and validate image in a using block to ensure proper disposal
            using (var image = Image.FromFile(sourcePath))
            {
                // Validate format (should be JPEG)
                if (!image.RawFormat.Equals(ImageFormat.Jpeg))
                {
                    return new ProcessingResult 
                    { 
                        Success = false, 
                        Message = $"✗ Обложка должна быть в формате JPEG (текущий: {image.RawFormat})" 
                    };
                }

                // Validate height (should be 900 pixels)
                if (image.Height != 900)
                {
                    return new ProcessingResult 
                    { 
                        Success = false, 
                        Message = $"✗ Высота обложки должна быть 900 пикселей (текущая: {image.Height}px)" 
                    };
                }

                // Check DPI (should be 300)
                if (Math.Abs(image.VerticalResolution - 300) > 1 || Math.Abs(image.HorizontalResolution - 300) > 1)
                {
                    return new ProcessingResult 
                    { 
                        Success = false, 
                        Message = $"✗ Разрешение обложки должно быть 300 DPI (текущее: {image.HorizontalResolution}x{image.VerticalResolution})" 
                    };
                }

                // Copy to output (done outside using block to avoid file lock issues)
                var destPath = Path.Combine(outputDir, outputFileName);
                var resultMessage = $"✓ Обложка обработана: {Path.GetFileName(destPath)} ({image.Width}x{image.Height}px, 300 DPI)";
                
                // Image will be disposed here before we copy the file
                File.Copy(sourcePath, destPath, true);

                return new ProcessingResult 
                { 
                    Success = true, 
                    Message = resultMessage
                };
            }
        }
        catch (Exception ex)
        {
            return new ProcessingResult { Success = false, Message = $"✗ Ошибка обработки обложки: {ex.Message}" };
        }
    }

    private ProcessingResult ProcessArticlePdf(string sourcePath, string outputDir)
    {
        try
        {
            if (!File.Exists(sourcePath))
            {
                return new ProcessingResult { Success = false, Message = $"✗ PDF файл не найден: {sourcePath}" };
            }

            // Validate PDF extension
            if (!Path.GetExtension(sourcePath).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
            {
                return new ProcessingResult 
                { 
                    Success = false, 
                    Message = $"✗ Файл должен быть в формате PDF: {Path.GetFileName(sourcePath)}" 
                };
            }

            // Copy to output
            var destPath = Path.Combine(outputDir, Path.GetFileName(sourcePath));
            File.Copy(sourcePath, destPath, true);

            return new ProcessingResult 
            { 
                Success = true, 
                Message = $"✓ PDF статьи скопирован: {Path.GetFileName(destPath)}" 
            };
        }
        catch (Exception ex)
        {
            return new ProcessingResult { Success = false, Message = $"✗ Ошибка обработки PDF: {ex.Message}" };
        }
    }

    private ProcessingResult ProcessCombinedPdf(string sourcePath, string outputDir)
    {
        try
        {
            if (!File.Exists(sourcePath))
            {
                return new ProcessingResult { Success = false, Message = $"✗ Объединенный PDF не найден: {sourcePath}" };
            }

            // Validate PDF extension
            if (!Path.GetExtension(sourcePath).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
            {
                return new ProcessingResult 
                { 
                    Success = false, 
                    Message = $"✗ Файл должен быть в формате PDF" 
                };
            }

            // Copy to output
            var destPath = Path.Combine(outputDir, "issue_combined.pdf");
            File.Copy(sourcePath, destPath, true);

            return new ProcessingResult 
            { 
                Success = true, 
                Message = $"✓ Объединенный PDF выпуска скопирован: {Path.GetFileName(destPath)}" 
            };
        }
        catch (Exception ex)
        {
            return new ProcessingResult { Success = false, Message = $"✗ Ошибка обработки объединенного PDF: {ex.Message}" };
        }
    }

    /// <summary>
    /// Verify that file names match the content in XML
    /// </summary>
    private VerificationResult VerifyFilesAgainstXml(Journal journal, ArchiveBuilderSettings settings, string articlesDir)
    {
        var result = new VerificationResult { Success = true };
        var errors = new List<string>();

        try
        {
            // Check if article PDFs match the articles in XML
            if (settings.ArticlePdfPaths != null && settings.ArticlePdfPaths.Any())
            {
                var xmlArticleCount = journal.Issue.Articles.ArticleList.Count;
                var pdfFileCount = settings.ArticlePdfPaths.Count;

                result.Messages.Add($"Статей в XML: {xmlArticleCount}");
                result.Messages.Add($"PDF файлов: {pdfFileCount}");

                if (xmlArticleCount != pdfFileCount)
                {
                    errors.Add($"⚠ Несоответствие: количество статей в XML ({xmlArticleCount}) не совпадает с количеством PDF файлов ({pdfFileCount})");
                }

                // Get actual PDF files once to avoid repeated file system operations
                var actualPdfFiles = Directory.GetFiles(articlesDir, "*.pdf")
                    .Select(f => Path.GetFileName(f))
                    .ToList();

                // Check for article file references in XML
                foreach (var article in journal.Issue.Articles.ArticleList)
                {
                    // Check if article has files information
                    if (article.Files != null && article.Files.FileList.Any())
                    {
                        foreach (var fileItem in article.Files.FileList)
                        {
                            var expectedFileName = fileItem.Value;
                            if (string.IsNullOrEmpty(expectedFileName))
                                continue;

                            if (!actualPdfFiles.Any(f => f != null && f.Equals(expectedFileName, StringComparison.OrdinalIgnoreCase)))
                            {
                                errors.Add($"⚠ Файл '{expectedFileName}' указан в XML, но не найден в папке статей");
                            }
                            else
                            {
                                result.Messages.Add($"✓ Файл '{expectedFileName}' найден");
                            }
                        }
                    }
                }

                // Verify all PDF files are accounted for
                var referencedFiles = journal.Issue.Articles.ArticleList
                    .Where(a => a.Files?.FileList != null && a.Files.FileList.Any())
                    .SelectMany(a => a.Files!.FileList)
                    .Select(f => f.Value)
                    .Where(v => !string.IsNullOrEmpty(v))
                    .ToList();

                foreach (var pdfFile in actualPdfFiles)
                {
                    if (!referencedFiles.Any(f => f.Equals(pdfFile, StringComparison.OrdinalIgnoreCase)))
                    {
                        errors.Add($"⚠ PDF файл '{pdfFile}' найден в папке, но не упомянут в XML");
                    }
                }
            }

            // Check cover files
            if (!string.IsNullOrEmpty(settings.CoverImageRussianPath))
            {
                result.Messages.Add("✓ Обложка на русском языке прикреплена");
            }

            if (!string.IsNullOrEmpty(settings.CoverImageEnglishPath))
            {
                result.Messages.Add("✓ Обложка на английском языке прикреплена");
            }

            // Set final result
            if (errors.Any())
            {
                result.Success = false;
                result.Errors = errors;
                result.Messages.Add($"\n⚠ Обнаружено ошибок верификации: {errors.Count}");
            }
            else
            {
                result.Messages.Add("\n✓ Верификация успешно пройдена");
            }
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Errors.Add($"Ошибка верификации: {ex.Message}");
            result.Messages.Add($"✗ Ошибка верификации: {ex.Message}");
        }

        return result;
    }
}

/// <summary>
/// Settings for archive builder
/// </summary>
public class ArchiveBuilderSettings
{
    public string OutputDirectory { get; set; } = string.Empty;
    public string? CoverImagePath { get; set; }
    public string? CoverImageRussianPath { get; set; }
    public string? CoverImageEnglishPath { get; set; }
    public List<string>? ArticlePdfPaths { get; set; }
    public string? CombinedPdfPath { get; set; }
    public string? XmlMetadataPath { get; set; }
}

/// <summary>
/// Result of archive building operation
/// </summary>
public class ArchiveBuilderResult
{
    public bool Success { get; set; }
    public bool CoverImageProcessed { get; set; }
    public bool CoverImageRussianProcessed { get; set; }
    public bool CoverImageEnglishProcessed { get; set; }
    public int ArticlePdfsProcessed { get; set; }
    public bool CombinedPdfProcessed { get; set; }
    public bool XmlMetadataGenerated { get; set; }
    public bool XmlMetadataAttached { get; set; }
    public bool VerificationPassed { get; set; }
    public List<string> Messages { get; set; } = new List<string>();
    public List<string> VerificationErrors { get; set; } = new List<string>();
}

/// <summary>
/// Result of single file processing
/// </summary>
internal class ProcessingResult
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
}

/// <summary>
/// Result of verification operation
/// </summary>
internal class VerificationResult
{
    public bool Success { get; set; }
    public List<string> Messages { get; set; } = new List<string>();
    public List<string> Errors { get; set; } = new List<string>();
}
