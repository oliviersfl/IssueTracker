using IssueTracker.Services;
using IssueTracker.Services.Database;
using IssueTracker.Services.Database.Repository;
using IssueTracker.Services.Database.Repository.Interfaces;
using IssueTracker.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IssueTracker
{
    static class Program
    {
        private static IServiceProvider ServiceProvider { get; set; }

        [STAThread]
        static async Task Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var services = new ServiceCollection();
            await ConfigureServices(services, configuration);

            ServiceProvider = services.BuildServiceProvider();

            var initializer = ServiceProvider.GetRequiredService<IDatabaseInitializer>();
            await initializer.InitializeAsync();

            var mainForm = ServiceProvider.GetRequiredService<MainForm>();
            Application.Run(mainForm);
        }

        private async static Task ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = configuration.Get<AppSettings>() ??
                throw new InvalidOperationException("Failed to bind AppSettings from configuration");
            services.AddSingleton(appSettings);
            services.AddSingleton<ITicketService, TicketService>();
            services.AddSingleton<MainForm>();


            // Database
            services.AddSingleton<IDatabaseService, SqliteDatabaseService>();
            services.AddTransient<IDatabaseInitializer, SqliteDatabaseInitializer>();
            services.AddTransient<IDatabaseBackupService>(provider =>
                new DatabaseBackupService(TimeSpan.FromHours(appSettings.Database.BackupHoursInterval))
            );
            services.AddScoped<IExcelExportService, ExcelExportService>();

            services.AddTransient<ITicketRepository, TicketRepository>();
        }
    }
}