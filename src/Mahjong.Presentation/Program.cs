using Mahjong;
using Mahjong.Model;
using Mahjong.Model.Configs;
using Mahjong.Model.Settings;
using Mahjong.Presentation;
using Mahjong.Presentation.Controls.ConsoleTextViews.Logging;
using Mahjong.Presentation.Dialogs;
using Mahjong.Presentation.Services;

internal static class Program
{
    [STAThread]
    private static void Main(string[] args)
    {
        var services = new ServiceCollection();
        services.ConfigureServices();
        services.ConfigureConfiguration();
        services.ConfigureLogging();
        services.BuildServiceProvider().RunApp();
    }

    private static void ConfigureServices(this IServiceCollection services)
    {
        services.AddSingleton<App>();
        services.AddSingleton<WindowService>();
        services.AddSingleton<MainWindow>();
        services.AddSingleton<MainWindowViewModel>();
        services.AddTransient<AboutDialog>();
        services.AddTransient<AboutDialogViewModel>();
        services.AddSingleton<ApplicationService>();
        services.AddSingleton<ISettingRepository, SettingRepository>();
    }

    private static void ConfigureConfiguration(this IServiceCollection services)
    {
        var condiguration = new ConfigurationBuilder();
        condiguration.AddSettingsJson();
        services.AddSingleton<IConfiguration>(condiguration.Build());
    }

    private static void ConfigureLogging(this IServiceCollection services)
    {
        var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
        services.AddLogging(
            logging =>
            {
                logging.ClearProviders();
                logging.AddCustomNLog(Paths.LogsDir);
                logging.AddConsoleTextView();
                logging.Configure(configuration);
            }
        );
    }

    private static void RunApp(this IServiceProvider serviceProvider)
    {
        var app = serviceProvider.GetRequiredService<App>();
        app.DispatcherUnhandledException +=
            (s, e) =>
            {
                e.Handled = true;
                serviceProvider.GetRequiredService<ILoggerFactory>().CreateLogger<MainWindow>().LogError("{ex}", e.Exception);
            };
        app.InitializeComponent();
        app.Run(serviceProvider.GetRequiredService<MainWindow>());
    }
}
