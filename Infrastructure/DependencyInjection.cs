using Application.Context;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        private static readonly string ConnectionString = "Server=localhost;Uid=root;Pwd=Pass1234+;Database=porrasapp;";

        public static IServiceCollection InitializeInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextFactory<AppDbContext>(options =>
                options.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString)),
                ServiceLifetime.Transient);
            //services.AddDbContext<AppDbContext>(opts => opts.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString)), ServiceLifetime.Transient, ServiceLifetime.Transient);
            services.AddTransient<IAppDbContext>(provider => provider.GetRequiredService<IDbContextFactory<AppDbContext>>().CreateDbContext());

            return services;
        }

    }
}
