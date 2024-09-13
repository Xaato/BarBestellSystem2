using Microsoft.EntityFrameworkCore;

namespace Application;

public class BarDbContext: DbContext
{
    public BarDbContext(DbContextOptions<BarDbContext> options) : base(options)
    {
    }
    public DbSet<Table> Tables { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<ArticleGroup> ArticleGroups { get; set; }
}