using Microsoft.Extensions.DependencyInjection;
using RetroBack.Domain.Repositories;
using RetroBack.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroBack.Persistence.Bootstrap
{
    public static class ServiceBuilderExtensions
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

        }
    }
}
