using Microsoft.Extensions.DependencyInjection;
using WorkHub.Application.Interfaces;
using WorkHub.Application.Services;

namespace WorkHub.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IProjectService, ProjectService>();
            return services;
        }
    }
}
