using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chatApp.Database;
using chatApp.Models;
using Microsoft.EntityFrameworkCore;

namespace chatApp.Infrastructure.Repository
{
    public class ChatRepository : IChatRepository
    {
        private AppDbContext _ctx;

        public ChatRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Message> CreateMessage(int chatId, string message, string name)
        {
            var Message = new Message
            {
                ChatId = chatId,
                Text = message,
                Name = name,
                Timestamp = DateTime.Now
            };

            _ctx.Messages.Add(Message);

            await _ctx.SaveChangesAsync();

            return Message;
        }

        public async Task<int> CreatePrivateRoom(string roomId, string targetId)
        {
            var chat = new Chat
            {
                Type = ChatType.Private
            };

            // Users is ChatUser
            chat.Users.Add(new ChatUser
            {
                UserId = targetId
            });

            chat.Users.Add(new ChatUser
            {
                UserId = roomId
            });

            _ctx.Chats.Add(chat);

            await _ctx.SaveChangesAsync();

            return chat.Id;
        }

        public async Task CreateRoom(string name, string userId)
        {
            var chat = new Chat
            {
                Name = name,
                Type = ChatType.Room
            };

            chat.Users.Add(new ChatUser
            {
                UserId = userId,
                Role = UserRole.Admin
            });

            _ctx.Chats.Add(chat);

            await _ctx.SaveChangesAsync();
        }

        public Chat GetChat(int id)
        {
            return _ctx.Chats.Include(x => x.Messages).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Chat> GetChats(string userId)
        {
            return _ctx.Chats
                .Include(x => x.Users)
                .Where(x => !x.Users.Any(y => y.UserId == userId) && x.Type == ChatType.Room)
                .ToList();
        }

        public IEnumerable<Chat> GetPrivateChats(string userId)
        {
            return _ctx.Chats
                .Include(x => x.Users)
                .ThenInclude(x => x.User)
                .Where(x => x.Type == ChatType.Private && x.Users.Any(y => y.UserId == userId))
                .ToList();
        }

        public async Task JoinRoom(int chatId, string userId)
        {
            var chatUser = new ChatUser
            {
                ChatId = chatId,
                UserId = userId,
                Role = UserRole.Menber
            };

            _ctx.ChatUsers.Add(chatUser);

            await _ctx.SaveChangesAsync();
        }
    }
}