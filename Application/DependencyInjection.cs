using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        const string dbPath = "/app/bar1.db";
        services.AddDbContextFactory<BarDbContext>(options => { options.UseSqlite($"Data Source={dbPath}"); });


        return services;
    }
}