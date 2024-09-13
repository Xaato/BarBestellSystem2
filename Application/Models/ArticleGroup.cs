namespace Application.Models;

public sealed class ArticleGroup
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<Article> Articles { get; set; }
}