﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO; 

namespace PaymentGateway.Core.Context
{
    public class ProcessPaymentContextFactoryHelper<T> : IDesignTimeDbContextFactory<T> where T : DbContext
    {
        public virtual T CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
              .AddEnvironmentVariables()
             .Build();

            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddJsonFile("appsettings.Development.json", optional: true)
               .AddJsonFile($"appsettings.Development.{config["ASPNETCORE_SUBENVIRONMENT"]}.json", optional: true)
               .Build();

            var builder = new DbContextOptionsBuilder<T>();
            builder.EnableSensitiveDataLogging(true);
            var connectionString = configuration["ConnectionStrings:Default"];
            builder.UseSqlServer(connectionString, b => b.MigrationsAssembly(this.GetType().Assembly.FullName));
            var dbContext = (T)Activator.CreateInstance(typeof(T), builder.Options);
            return dbContext;
        }
    }
}
