using System.Collections.Generic;

namespace TheBulletin.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool IsAdmin { get; set; }
        public List<Message> Msges { get; set; } = new();
    }
}
