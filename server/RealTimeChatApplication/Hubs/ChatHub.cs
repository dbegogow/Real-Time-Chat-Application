using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using RealTimeChatApplication.Models;

namespace RealTimeChatApplication.Hubs
{
    public class ChatHub : Hub
    {
        private readonly string _botUser;
        private readonly IDictionary<string, UserConnection> _connections;

        public ChatHub(IDictionary<string, UserConnection> connections)
        {
            this._botUser = "MyChat Bot";
            this._connections = connections;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            if (this._connections.TryGetValue(Context.ConnectionId, out UserConnection userConnection))
            {
                this._connections.Remove(Context.ConnectionId);

                this.Clients
                    .Group(userConnection.Room)
                    .SendAsync("ReceiveMessage", _botUser, $"{userConnection.User} has left");
            }

            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string message)
        {
            if (this._connections.TryGetValue(Context.ConnectionId, out UserConnection userConnection))
            {
                await Clients
                    .Group(userConnection.Room)
                    .SendAsync("ReceiveMessage", userConnection.User, message);
            }
        }

        public async Task JoinRoom(UserConnection userConnection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.Room);

            this._connections[Context.ConnectionId] = userConnection;

            await Clients
                .Group(userConnection.Room)
                .SendAsync("ReceiveMessage", this._botUser, $"{userConnection.User} has joined {userConnection.Room}");
        }
    }
}
