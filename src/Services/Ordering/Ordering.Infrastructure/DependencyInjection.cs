using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Data;
using Ordering.Infrastructure.Data;
using Ordering.Infrastructure.Data.Interceptors;

namespace Ordering.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");

            services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptors>();
            services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventInterceptor>();
            

            services.AddDbContext<AppDbContext>((sp, opt) =>
            {
                opt.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                opt.UseSqlServer(connectionString);
            });

            services.AddScoped<IApplicationDbContext, AppDbContext>();
                
            return services;
        }
    }
}
