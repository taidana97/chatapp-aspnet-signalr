using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace chatApp.Models
{
    public class User : IdentityUser
    {
        public ICollection<ChatUser> Chats { get; set; }
    }
}