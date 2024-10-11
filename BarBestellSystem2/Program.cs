using Application;
using BarBestellSystem2.Hubs;
using Microsoft.AspNetCore.ResponseCompression;

namespace BarBestellSystem2;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddBlazorBootstrap();
        builder.Services.AddApplication();
        //builder.Services.AddSignalR();
        builder.Services.AddResponseCompression(opts =>
        {
            opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                ["application/octet-stream"]);
        });
        builder.Services.AddScoped<BlazorBootstrap.SortableListJsInterop>();
        builder.Services.AddScoped<BlazorBootstrap.ToastService>();
        var app = builder.Build();
        app.UseResponseCompression();
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");
        //app.MapHub<NotificationHub>("/notificationHub");
        app.Run();
    }
}