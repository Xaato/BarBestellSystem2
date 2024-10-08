using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace BarBestellSystem2.Pages
{
    [Authorize]
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnGet(string redirectUri = "/Login")
        {
            // Logout von Auth0 und Cookies
            var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
                .WithRedirectUri(redirectUri)
                .Build();

            // Abmelden von Auth0
            await HttpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
            // Abmelden von Cookie-Authentifizierung
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Weiterleitung zur Login-Seite
            return RedirectToPage(redirectUri);
        }
    }
}
