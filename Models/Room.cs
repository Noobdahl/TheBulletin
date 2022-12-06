using System.Collections.Generic;

namespace TheBulletin.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string Name { get; set; } = null!;
        public List<Message> Msges { get; set; } = new();
    }
}
