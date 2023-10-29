using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly()); 
            return services;
        }
    }
}
