using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows.Forms;

namespace WinFormsApp1
{
    internal static class Program
    {
        public static IHost? AppHost { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            AppHost = Host.CreateDefaultBuilder().ConfigureServices((hostContext, services) =>
            {
                services.AddHttpClient();
                services.AddTransient<IBaseRepositoryEx, BaseRepositoryEx>();
                services.AddTransient<IHierarchicalPayanarTypeColumnRepository, HierarchicalPayanarTypeColumnRepository>();
                services.AddTransient<IHierarchicalPayanarTypeRepository, HierarchicalPayanarTypeRepository>();
                services.AddTransient<IPayanarTableDesignRepository, PayanarTableDesignRepository>();
                services.AddTransient<IPayanarTableDesignssRepository, PayanarTableDesignssRepository>();
                services.AddSingleton<Form1>();
            }).Build();
            AppHost.StartAsync();
            Application.Run(AppHost.Services.GetRequiredService<Form1>());
            AppHost.StopAsync();
        }
    }
}