using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Models;

public class Article
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    [ForeignKey("ArticleGroup")]
    public int ArticleGroupId { get; set; }
    public ArticleGroup ArticleGroup { get; set; }
}