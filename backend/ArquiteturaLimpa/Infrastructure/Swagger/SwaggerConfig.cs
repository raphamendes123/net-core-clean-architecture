using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PearlCore.Security;

namespace Infrastructure.Swagger
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddDocumentacaoSwagger(this IServiceCollection services)
        {
            services.AddDocumentationSwagger(new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "XXXXXXXXXX.WebApi",
                Description = "Api responsible XXXXXXXXXX",
                Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                {
                    Name = "Developer => Raphael Mendes de Oliveira - linkedin - Add ",
                    Url = new Uri("https://www.linkedin.com/in/raphael-mendes-br/"), 
                }
            });
            services.AddSwaggerGen();

            return services;
        }

        public static WebApplication AddSwagger(this WebApplication webApplication)
        {
            webApplication.UseSwagger();
            webApplication.UseSwaggerUI();
            webApplication.UseSwaggerDocumentation("XXXXXXXXXX.WebApi");

            return webApplication;
        }
    }
}
