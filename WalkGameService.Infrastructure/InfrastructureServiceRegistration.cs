using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Web;
using WalkGameService.Domain;

namespace WalkGameService.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, ILoggingBuilder logging, ConfigureHostBuilder host)
        {
            logging.ClearProviders();
            host.UseNLog();

            services.AddSingleton<IMapService, MapService>();

            return services;
        }
    }
}
