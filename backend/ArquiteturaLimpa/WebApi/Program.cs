using Infrastructure.AutoMapper;
using Infrastructure.Cors;
using Infrastructure.DependencyInjection;
using Infrastructure.FluentValidation;
using Infrastructure.JwtBearer;
using Infrastructure.Policy;
using Infrastructure.Swagger;

var appsettings = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDocumentacaoSwagger();
builder.Services.AddJwtBearer();
builder.Services.AddPolicy();
builder.Services.AddDependencyInjection(); 
builder.Services.AddAutoMapper();
builder.Services.AddFluentValidation();

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.AddCors(appsettings.Build().GetSection("host").Value.Trim());
app.AddSwagger();
app.AddCultureInfo("pt-BR");

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.UseAuthorization();
app.UseStaticFiles();
app.UseForwardedHeaders();

app.Run();
