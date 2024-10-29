using Application.Hubs;
using Application.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Application;

public class BarService
{
    private readonly IDbContextFactory<BarDbContext> _dbFactory;
    private readonly IHubContext<NotificationHub> _hubContext;

    public BarService(IDbContextFactory<BarDbContext> dbFactory, IHubContext<NotificationHub> hubContext)
    {
        _dbFactory = dbFactory;
        _hubContext = hubContext;
    }

    public async Task<List<Order>> LoadOrdersAsync()
    {
        await using var context = await _dbFactory.CreateDbContextAsync();

        return await context.Orders
            .Where(order => !order.IsCompleted)
            .Include(order => order.OrderArticles)
            .ThenInclude(orderArticle => orderArticle.Article)
            .ToListAsync();
    }

    public async Task UpdateOrderArticleAsync(OrderArticle orderArticle)
    {
        await using var context = await _dbFactory.CreateDbContextAsync();
        context.Attach(orderArticle);
        context.Entry(orderArticle).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task UpdateOrderAsync(Order order)
    {
        await using var context = await _dbFactory.CreateDbContextAsync();
        context.Attach(order);
        context.Entry(order).State = EntityState.Modified;
        await context.SaveChangesAsync();
        if (order.IsCompleted)
        {
            var message = $"Order {order.Id} for table {order.TableId} is completed";
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", order.Employee,
                message);
        }
    }
}