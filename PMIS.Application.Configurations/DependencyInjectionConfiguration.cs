using Microsoft.Extensions.DependencyInjection;
using PMIS.Database;
using PMIS.Repositories;
using PMIS.Repositories.Abstractions;
using PMIS.Services;
using PMIS.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Application.Configurations
{
    public static class DependencyInjectionConfigurationExtensions
    {
        public static void AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IEmployeeRepository, EmployeeRepository>();
            serviceCollection.AddTransient<ICustomerRepository, CustomerRepository>();
            serviceCollection.AddTransient<IProductRepository, ProductRepository>();
            serviceCollection.AddTransient<ICustomerCategoryRepository, CustomerCategoryRepository>();

            serviceCollection.AddTransient<EcommerceDbContext>();

        }

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ICustomerCategoryService, CustomerCategoryService>();
            services.AddTransient<IPaymentGatewayService, PaymentGatewayService>();
        }
    }
}
