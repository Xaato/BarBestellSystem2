using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Models;

public sealed class Order
{
    public int Id { get; set; }
    public IEnumerable<OrderArticle> OrderArticles { get; set; }
    [ForeignKey("Table")]
    public int TableId { get; set; }
    public Table Table { get; set; }
    public DateTime Timestamp { get; set; }
}
