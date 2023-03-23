using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xpto.Core.Customers;
using Xpto.Repositories.Customers;
using Xpto.Repositories.Shared.Sql;
using Xpto.Services.Customers;

namespace Xpto.UI
{
    internal static class Program
    {
 
        [STAThread]
        static void Main()
        {

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;
            ApplicationConfiguration.Initialize();

            Application.Run(ServiceProvider.GetRequiredService<FrmApp>());
        }

        public static IServiceProvider ServiceProvider { get; private set; }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
      
                    services.AddTransient<FrmApp>();
                    services.AddTransient<FrmCustomerRegister>();
                    services.AddTransient<FrmCustomerSearch>();

                    services.AddTransient<SqlConnectionProvider>(_ => new SqlConnectionProvider("server=.;database=db_xpto;user=xpto;password=123456"));
                    services.AddTransient<ICustomerRepository, CustomerRepository>();
                    services.AddTransient<ICustomerService, CustomerService>();

                });
        }
    }
}