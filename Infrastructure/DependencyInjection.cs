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

        public static void InitializeDependencies(this IServiceCollection services, IConfiguration configuration)
        { 
            services.AddDbContext<AppDbContext>(opts => opts.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString)), ServiceLifetime.Scoped, ServiceLifetime.Scoped);
            services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<IDbContextFactory<AppDbContext>>().CreateDbContext());
            services.AddMediatR(_ => _.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

    }
}
