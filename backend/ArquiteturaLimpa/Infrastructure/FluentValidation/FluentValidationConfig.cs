using Application.Common.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;
using ZymLabs.NSwag.FluentValidation;

namespace Infrastructure.FluentValidation
{
    public static class FluentValidationConfig
    {
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            services.AddScoped<FluentValidationSchemaProcessor>(provider =>
            {
                var validationRules = provider.GetService<IEnumerable<FluentValidationRule>>();
                var loggerFactory = provider.GetService<ILoggerFactory>();

                return new FluentValidationSchemaProcessor(provider, validationRules, loggerFactory);
            });
 
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); 
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));     
            });
         
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.Load("Application")); 

            return services;
        }

    }
}
