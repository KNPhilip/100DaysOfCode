using Microsoft.AspNetCore.SignalR;

namespace TeamChatting.Hubs;

public sealed class ProcurementChat : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
