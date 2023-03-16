using Microsoft.Extensions.DependencyInjection;
using Xpto.Core.Customers;
using Xpto.Repositories.Customers;
using Xpto.Repositories.Shared.Sql;
using Xpto.Services.Customers;

namespace Xpto.Test
{
    [TestClass]
    public class Dependency
    {
        public ICustomerService customerService;

        [TestInitialize]
        public void Init()
        {
           var services = new ServiceCollection();
            services.AddTransient<SqlConnectionProvider>(_ => new SqlConnectionProvider("server=.;database=db_xpto;user=xpto;password=123456"));
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerService, CustomerService>();


            var provider = services.BuildServiceProvider();
 
            this.customerService = provider.GetService<ICustomerService>();

        }
    }
}
