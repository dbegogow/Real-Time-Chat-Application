using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using RealTimeChatApplication.Models;

namespace RealTimeChatApplication.Hubs
{
    public class ChatHub : Hub
    {
        private readonly string _botUser;

        public ChatHub()
        {
            this._botUser = "MyChat Bot";
        }

        public async Task JoinRoom(UserConnection userConnection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.Room);

            await Clients
                .Group(userConnection.Room)
                .SendAsync("ReceiveMessage", this._botUser, $"{userConnection.User} has joined {userConnection.Room}");
        }
    }
}
