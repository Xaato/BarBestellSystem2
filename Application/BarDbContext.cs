using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Application;

public class BarDbContext : DbContext
{
    public BarDbContext(DbContextOptions<BarDbContext> options) : base(options) {}

    public DbSet<Table> Tables { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<ArticleGroup> ArticleGroups { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderArticle> OrderArticles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Table>().HasData(
            new Table { Id = 1, Name = "Table 1", X = 0, Y = 0 },
            new Table { Id = 2, Name = "Table 2", X = 100, Y = 150 },
            new Table { Id = 3, Name = "Table 3", X = 200, Y = 300 },
            new Table { Id = 4, Name = "Table 4", X = 300, Y = 450 },
            new Table { Id = 5, Name = "Table 5", X = 400, Y = 600 },
            new Table { Id = 6, Name = "Table 6", X = 500, Y = 750 },
            new Table { Id = 7, Name = "Table 7", X = 600, Y = 900 },
            new Table { Id = 8, Name = "Table 8", X = 700, Y = 1050 }
        );

        modelBuilder.Entity<ArticleGroup>().HasData(
            new ArticleGroup { Id = 1, Name = "Drinks" },
            new ArticleGroup { Id = 2, Name = "Food" },
            new ArticleGroup { Id = 3, Name = "Desserts" }
        );

        modelBuilder.Entity<Article>().HasData(
            new Article { Id = 1, Name = "Beer", Price = 3.50m, ArticleGroupId = 1 },
            new Article { Id = 2, Name = "Wine", Price = 4.50m, ArticleGroupId = 1 },
            new Article { Id = 3, Name = "Soda", Price = 2.00m, ArticleGroupId = 1 },
            new Article { Id = 4, Name = "Pizza", Price = 8.50m, ArticleGroupId = 2 },
            new Article { Id = 5, Name = "Burger", Price = 7.50m, ArticleGroupId = 2 },
            new Article { Id = 6, Name = "Fries", Price = 3.50m, ArticleGroupId = 2 },
            new Article { Id = 7, Name = "Ice Cream", Price = 4.50m, ArticleGroupId = 3 },
            new Article { Id = 8, Name = "Cake", Price = 5.50m, ArticleGroupId = 3 }
        );
    }
}