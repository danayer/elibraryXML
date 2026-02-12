using elibraryXMLApp.Services;
using Microsoft.Extensions.DependencyInjection;

namespace elibraryXMLApp;

static class Program
{
    /// <summary>
    /// Service provider for dependency injection
    /// </summary>
    public static ServiceProvider ServiceProvider { get; private set; } = null!;

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // Configure services for dependency injection
        var services = new ServiceCollection();
        ConfigureServices(services);
        ServiceProvider = services.BuildServiceProvider();

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        
        // Show startup form first
        var startupForm = ServiceProvider.GetRequiredService<StartupForm>();
        var result = startupForm.ShowDialog();
        
        // If user chose an option, open main form with loaded data
        if (result == DialogResult.OK && startupForm.ShouldContinue)
        {
            var mainForm = ActivatorUtilities.CreateInstance<Form1>(
                ServiceProvider, 
                startupForm.LoadedJournal!);
            Application.Run(mainForm);
        }

        // Dispose service provider on exit
        ServiceProvider.Dispose();
    }

    /// <summary>
    /// Configure dependency injection services
    /// </summary>
    private static void ConfigureServices(IServiceCollection services)
    {
        // Register services as singletons (one instance for the application lifetime)
        services.AddSingleton<IXmlService, XmlService>();
        services.AddSingleton<IJsonService, JsonService>();
        services.AddSingleton<ITextParsingService, TextParsingService>();
        services.AddSingleton<IHtmlParsingService, HtmlParsingService>();
        services.AddSingleton<IJatsExportService, JatsExportService>();
        services.AddSingleton<IJournal3ExportService, Journal3ExportService>();
        
        // ArchiveBuilderService needs IXmlService, registered as transient (new instance each time)
        services.AddTransient<IArchiveBuilderService, ArchiveBuilderService>();

        // Register forms
        services.AddTransient<StartupForm>();
        services.AddTransient<Form1>();
        services.AddTransient<ArchiveBuilderForm>();
        services.AddTransient<ManualParserForm>();
    }
}