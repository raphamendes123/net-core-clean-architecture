using Microsoft.AspNetCore.Builder;

namespace Infrastructure.Cors
{
    public static class CorsConfig
    {
        public static WebApplication AddCors(this WebApplication webApplication, string host)
        {
            webApplication.UseCors("CorsPolicy");
            webApplication.UseCors(x => x.AllowAnyMethod()
                              .AllowAnyOrigin()
                              .AllowAnyHeader());
            webApplication.UseCors(options =>
              options.WithOrigins("http://localhost:4200/", host)
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowAnyHeader()
                );
            return webApplication;
        }
    }
}
