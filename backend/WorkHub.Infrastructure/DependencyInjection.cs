using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkHub.Application.Interfaces;
using WorkHub.Infrastructure.Data;
using WorkHub.Infrastructure.Repositories;

namespace WorkHub.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WorkHubDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection")
                    ?? "Host=localhost;Database=workhub;Username=postgres;Password=postgres";
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<IProjectRepository, ProjectRepository>();
            return services;
        }
    }
}
