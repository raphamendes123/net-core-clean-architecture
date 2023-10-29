using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace Infrastructure.Cors
{
    public static class CultureInfoConfig
    {
        public static WebApplication AddCultureInfo(this WebApplication webApplication, string cultureInfo)
        {
            var cultureInfos = new List<CultureInfo>();
            var culture = new CultureInfo(cultureInfo);
            culture.NumberFormat.NumberDecimalSeparator = ",";
            cultureInfos.Add(culture);

            webApplication.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(culture: cultureInfo, uiCulture: cultureInfo),
                SupportedCultures = cultureInfos,
                SupportedUICultures = cultureInfos,
            });


            return webApplication;
        }
    }
}
