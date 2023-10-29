using Infrastructure.AutoMapper.User;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
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
