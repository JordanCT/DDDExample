using DDDExample.Application.Interfaces;
using DDDExample.Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DDDExample.Application
{
    public static class Configuration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient <IClienteService, ClienteService>();
            services.AddTransient<ICuentaService, CuentaService>();
            return services;
        }
    }
}
