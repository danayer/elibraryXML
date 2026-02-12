using elibraryXMLApp.Models;

namespace elibraryXMLApp.Services;

/// <summary>
/// Interface for building issue archives with all required files
/// </summary>
public interface IArchiveBuilderService
{
    /// <summary>
    /// Validate and build archive structure
    /// </summary>
    ArchiveBuilderResult BuildArchive(Journal journal, ArchiveBuilderSettings settings);
}
