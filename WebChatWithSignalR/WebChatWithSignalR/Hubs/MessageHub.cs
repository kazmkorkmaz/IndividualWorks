using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebChatWithSignalR.Web.Hubs
{
    public class MessageHub:Hub
    {
        public class Client
        {
            public string ConnectionId { get; set; }
            public string userName { get; set; }
            public string groupName { get; set; }
        }
        static List<Client> clients = new List<Client>();
        public async Task AddToGroup(string group, string user)
        {
            Client client = new Client();
            client.ConnectionId = Context.ConnectionId;
            client.userName = user;
            client.groupName = group;
            clients.Add(client);
            await Clients.All.SendAsync("UserJoin", user);
            await Clients.All.SendAsync("clients", clients);
            await Groups.AddToGroupAsync(client.ConnectionId, group);
        }
        public async Task SendMessageToGroup(string group, string user, string message)
        {
            await Clients.Group(group).SendAsync("ReceiveMessage", user, message);
        }
        public async Task SendMessageToAll(string all, string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        public override Task OnConnectedAsync()
        {

            return base.OnConnectedAsync();
        }
    }
}
