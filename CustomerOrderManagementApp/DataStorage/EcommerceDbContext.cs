﻿using CustomerOrderManagementApp.Models.EntityModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CustomerOrderManagementApp.DataStorage
{
    public class EcommerceDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerCategory> CustomersCategories { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<PersonalInformation> PersonalInformation { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "User Id=INVEST;Password=icml1234;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.27.250)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCLPDB)))";
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseOracle(connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }
    }
}