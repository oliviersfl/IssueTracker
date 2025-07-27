using IssueTracker.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IssueTracker
{
    static class Program
    {
        private static IServiceProvider ServiceProvider { get; set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var services = new ServiceCollection();
            ConfigureServices(services, configuration);

            ServiceProvider = services.BuildServiceProvider();

            var mainForm = ServiceProvider.GetRequiredService<MainForm>();
            Application.Run(mainForm);
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = configuration.Get<AppSettings>() ??
                throw new InvalidOperationException("Failed to bind AppSettings from configuration");
            services.AddSingleton(appSettings);
            services.AddSingleton<ITicketService, TicketService>();
            services.AddSingleton<MainForm>();
        }
    }
}