using System.Collections.Generic;
using System.Threading.Tasks;
using chatApp.Models;

namespace chatApp.Infrastructure.Repository
{
    public interface IChatRepository
    {
        Chat GetChat(int id);

        Task CreateRoom(string name, string userId);

        Task JoinRoom(int chatId, string userId);

        IEnumerable<Chat> GetChats(string userId);

        Task<int> CreatePrivateRoom(string roomId, string targetId);

        IEnumerable<Chat> GetPrivateChats(string userId);

        Task<Message> CreateMessage(int chatId, string message, string name);
    }
}