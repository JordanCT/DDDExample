using DDDExample.Domain.Interfaces;
using DDDExample.Infrastructure.Context;
using DDDExample.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DDDExample.Infrastructure
{
    public static class Configuration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<DemoCuentasContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DemoCuentasConnection"),
                    x => x.MigrationsAssembly(typeof(DemoCuentasContext).Assembly.FullName)));

            services.AddTransient<DemoCuentasContext>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<ICuentaRepository, CuentaRepository>();
            return services;
        }
    }
}
