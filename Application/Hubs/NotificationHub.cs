using Microsoft.AspNetCore.SignalR;

namespace Application.Hubs;

public class NotificationHub : Hub
{
    public async Task SendNotification(string userId, string message)
    {
        await Clients.All.SendAsync("ReceiveNotification", userId, message);
    }
    public async Task NewOrderPlaced()
    {
        await Clients.All.SendAsync("UpdateOrderList");
    }
}