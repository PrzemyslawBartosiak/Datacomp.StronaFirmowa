using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace DataComp.StronaFirmowa.Strona.Controllers
{
    [Route("[controller]/[action]")]
    public class CultureController : Controller
    {
        public IActionResult Set(string culture, string redirectUri)
        {
            if (!string.IsNullOrEmpty(culture))
            {
                HttpContext.Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture, culture)),
                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1), IsEssential = true, Path = "/" }
                );
            }

            // Decode the redirectUri so Url.IsLocalUrl can validate it correctly
            if (!string.IsNullOrWhiteSpace(redirectUri))
            {
                redirectUri = Uri.UnescapeDataString(redirectUri);
            }

            if (string.IsNullOrWhiteSpace(redirectUri) || !Url.IsLocalUrl(redirectUri))
                redirectUri = "/";

            return LocalRedirect(redirectUri);
        }
    }
}