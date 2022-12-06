using System;

namespace TheBulletin.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public string? Msg { get; set; }
        public int RoomId { get; set; }
        public DateTime Time { get; set; }
    }
}
