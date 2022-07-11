using Microsoft.AspNetCore.SignalR;

namespace Sallamation.Server.Hubs
{
    public class AuthHub : Hub
    {
        public async Task Login(string email, string password)
        {
            await Clients.All.SendAsync("ReceiveMessage", email, password);
        }
    }
}