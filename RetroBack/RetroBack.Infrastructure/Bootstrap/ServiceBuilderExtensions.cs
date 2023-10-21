using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RetroBack.Common.Identity;
using RetroBack.Infrastructure.RequestBehaviors;
using RetroBack.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroBack.Infrastructure.Bootstrap
{
    public static class ServiceBuilderExtensions
    {
        public static void RegisterInfrastructureComponents(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CurrentUserBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CurrentUserBehavior<,>));

            services.AddScoped<ICurrentUserService, CurrentUserService>();
        }
    }
}
