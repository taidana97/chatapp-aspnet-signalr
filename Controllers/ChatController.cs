using System;
using System.Threading.Tasks;
using chatApp.Database;
using chatApp.Models;
using chatApp.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using chatApp.Infrastructure.Repository;
using chatApp.Infrastructure;

namespace chatApp.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ChatController : BaseController
    {
        private IHubContext<ChatHub> _chat;

        public ChatController(IHubContext<ChatHub> chat)
        {
            _chat = chat;
        }

        // clear chuyen qua chathub
        // [HttpPost("[action]/{connectionId}/{roomId}")]
        // public async Task<IActionResult> JoinRoom(string connectionId, string roomId)
        // {
        //     await _chat.Groups.AddToGroupAsync(connectionId, roomId);

        //     return Ok();
        // }

        // [HttpPost("[action]/{connectionId}/{roomId}")]
        // public async Task<IActionResult> LeaveRoom(string connectionId, string roomId)
        // {
        //     await _chat.Groups.RemoveFromGroupAsync(connectionId, roomId);

        //     return Ok();
        // }


    }
}