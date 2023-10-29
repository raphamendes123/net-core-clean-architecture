using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Policy
{   
    public static class PolicyConfig
    {
        public static IServiceCollection AddPolicy(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrator", policy => policy.RequireClaim("Administrator"));
                options.AddPolicy("UserStandard", policy => policy.RequireClaim("UserStandard"));
            });

            return services;
        }
    }
}
