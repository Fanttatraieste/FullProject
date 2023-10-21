using Microsoft.Extensions.DependencyInjection;
using RetroBack.Application.Interfaces;
using RetroBack.Application.Services;

namespace RetroBack.Application.Bootstrap
{
    public static class ServiceBuilderExtensions
    {
        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IJwtTokenService, JwtTokenService>(); 
        }
    }
}
