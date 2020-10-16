using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace chatApp.Hubs
{
    public class ChatHub : Hub
    {
        // public string GetConnectionId() => Context.ConnectionId;        

        public Task JoinRoom(string roomId)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, roomId);
        }

        public Task LeaveRoom(string roomId)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId);
        }
    }
}