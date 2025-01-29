using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PMIS.Models.EntityModels;
using System.Diagnostics;

namespace PMIS.Database
{
    public class EcommerceDbContext : DbContext
    {
        IConfiguration _configuration; 
        public EcommerceDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerCategory> CustomersCategories { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<PersonalInformation> PersonalInformation { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string connectionString = "User Id=INVEST;Password=icml1234;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.27.250)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCLPDB)))";
            //string connectionString = _configuration.GetConnectionString("AppConnectionString");
            string connectionString = _configuration["ConnectionStrings:OracleConnection"];
            optionsBuilder
                .UseOracle(connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }
    }
}
