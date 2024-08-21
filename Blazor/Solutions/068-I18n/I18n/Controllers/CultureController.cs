using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace I18n.Controllers;

[Route("[controller]/[action]")]
public sealed class CultureController : Controller
{
    public IActionResult Set(string culture, string redirectUri)
    {
        if (culture is not null)
        {
            RequestCulture requestCulture = new(culture, culture);
            string cookieName = CookieRequestCultureProvider.DefaultCookieName;
            string cookieValue = CookieRequestCultureProvider.MakeCookieValue(requestCulture);

            HttpContext.Response.Cookies.Append(cookieName, cookieValue);
        }

        return LocalRedirect(redirectUri);
    }
}
