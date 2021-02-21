using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaymentGateway.Core.Context;
using PaymentGateway.Core.Repository;
using PaymentGateway.Core.Repository.Interfaces;
using PaymentGateway.Core.Services;
using PaymentGateway.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway
{
    public partial class Startup
    {
        public void ConfigureDIService(IServiceCollection services)
        {

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IRepository<>), typeof(EntityRepository<>));

            services.AddScoped<IDbContext, PaymentGatewayDbContext>();
            services.AddScoped<IPaymentService, PaymentService>();

            services.AddTransient<IDbConnection>(dbCon =>
            {
                return new SqlConnection(Configuration.GetConnectionString("Default"));
            });
        }
    }
}
