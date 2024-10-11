using Application;
using BarBestellSystem2.Hubs;
using Microsoft.AspNetCore.ResponseCompression;
using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;         
using Microsoft.AspNetCore.Authentication.Cookies;

namespace BarBestellSystem2;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Auth0 Web App Authentication konfigurieren
        builder.Services.AddAuth0WebAppAuthentication(options =>
        {
            options.Domain = builder.Configuration["Auth0:Domain"];
            options.ClientId = builder.Configuration["Auth0:ClientId"];
            options.Scope = "openid profile email";
        });

        // Razor Pages und Seiten mit Authentifizierung konfigurieren
        builder.Services.AddRazorPages(options =>
        {
            options.Conventions.AuthorizePage("/TableMap");
            options.Conventions.AuthorizePage("/Ordering");
            options.Conventions.AuthorizePage("/kitchen/ordersoverview");
        });

        builder.Services.AddServerSideBlazor();
        builder.Services.AddApplication();
        builder.Services.AddSignalR();
        builder.Services.AddResponseCompression(opts =>
        {
            opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                ["application/octet-stream"]);
        });
        builder.Services.AddScoped<BlazorBootstrap.SortableListJsInterop>();

        var app = builder.Build();
        app.UseResponseCompression();
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        // Authentifizierung und Autorisierung aktivieren
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");
        app.MapHub<NotificationHub>("/notificationHub");
        app.Run();
    }
}
