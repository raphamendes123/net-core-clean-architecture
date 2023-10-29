using Microsoft.Extensions.Configuration;

namespace Base
{
    public static class ConnectionString
    {
        public static string ReturnConnectionString()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var server = builder.Build().GetSection("server").Value.Trim();
            var database = builder.Build().GetSection("database").Value.Trim();
            var userid = "usercotacaofarmacia";
            var password = "123456";
 
            var connectionstring = $"Server={server};Database={database};User Id={userid};Password={password}";

            return connectionstring;
        }

        public static string ReturnConnectionStringHangFire()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var server = builder.Build().GetSection("server").Value.Trim();
            var database = builder.Build().GetSection("database").Value.Trim() + "_HANGFIRE";
            var userid = "usercotacaofarmacia";
            var password = "123456";

            var connectionstring = $"Server={server};Database={database};User Id={userid};Password={password}";

            return connectionstring;

        }


    }
}
