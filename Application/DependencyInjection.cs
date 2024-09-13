using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        const string dbPath = "bar1.db";
        services.AddDbContext<BarDbContext>(options =>
        {
            options.UseSqlite($"Data Source={dbPath}");
        });

        return services;
    }
}