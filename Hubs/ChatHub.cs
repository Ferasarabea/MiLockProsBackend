using Microsoft.AspNetCore.SignalR;

namespace MiLockProsBackend.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string sender, int jobId, string messageText)
        {
            await Clients.All.SendAsync("ReceiveMessage", sender, messageText);
        }
    }
}

