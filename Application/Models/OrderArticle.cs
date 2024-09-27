using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Models;

public sealed class OrderArticle
{
    public int Id { get; set; }
    [ForeignKey("Article")]
    public int ArticleId { get; set; }
    public Article Article { get; set; }
    [ForeignKey("Order")]
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public int Amount { get; set; }
    public bool IsCompleted { get; set; }
}
