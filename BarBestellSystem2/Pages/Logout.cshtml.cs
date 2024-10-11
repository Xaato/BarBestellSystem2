using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;  

namespace BarBestellSystem2.Pages
{
    [Authorize]
    public class LogoutModel : PageModel
    {
        private readonly IConfiguration _configuration;

        // Konstruktor, um die Konfiguration zu injizieren
        public LogoutModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> OnGet(string redirectUri = "/Login")
        {
            // Auth0 Logout URL erstellen
            var logoutUrl = $"https://{_configuration["Auth0:Domain"]}/v2/logout?client_id={_configuration["Auth0:ClientId"]}&returnTo={redirectUri}";

            // Abmelden von Auth0
            await HttpContext.SignOutAsync(Auth0Constants.AuthenticationScheme);

            // Abmelden von Cookie-Authentifizierung
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Weiterleitung zur Auth0 Logout-URL
            return Redirect(logoutUrl);
        }
    }
}
