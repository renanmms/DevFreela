using DevFreela.Application.Commands.InsertProject;
using DevFreela.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DevFreela.Application.Extensions
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddScoped<IProjectService, ProjectService>()
                .AddHandlers();

            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services) 
        {
            services.AddMediatR(config => 
                config.RegisterServicesFromAssemblyContaining<InsertProjectCommand>());

            return services;
        }

    }
}