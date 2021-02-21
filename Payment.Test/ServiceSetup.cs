using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaymentGateway.Core.Context;
using PaymentGateway.Core.Repository;
using PaymentGateway.Core.Repository.Interfaces;
using System;
using TestSupport.EfHelpers;
using Xunit;

namespace Payment.Test
{
    public class ServiceSetup
    {
        public IConfiguration Configuration { get; }
        public ServiceSetup()
        {
            var options = SqliteInMemory.CreateOptions<PaymentGatewayDbContext>();

            Context = new PaymentGatewayDbContext(options);
            UnitOfWork = new UnitOfWork(Context);

            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IConfiguration>(new ConfigurationBuilder().Build())
                .AddDbContext<PaymentGatewayDbContext>(o => o.UseSqlite("DataSource=:memory:", x => { }));

            services.AddLogging();

            var provider = services.BuildServiceProvider();

            Context.Database.OpenConnection();
            Context.Database.EnsureCreated();
        }

        public PaymentGatewayDbContext Context { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();
        }
    }
}
