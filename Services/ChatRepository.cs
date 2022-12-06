using System.Collections.Generic;
using System.Linq;
using TheBulletin.Data;
using TheBulletin.Models;

namespace TheBulletin.Services
{
    internal class ChatRepository
    {
        private readonly AppDbContext _context;



        public ChatRepository(AppDbContext context)
        {
            _context = context;
        }





        //Get all messages by room
        public List<Message> GetAllMessagesByRoom(int roomId)
        {
            return _context.Messages.Where(m => m.RoomId == roomId).ToList();
        }

        //Get all rooms
        public List<Room> GetAllRooms()
        {
            return _context.Rooms.ToList();
        }

        //Create message
        public void AddMessage(Message message)
        {
            _context.Messages.Add(message);
        }

    }
}
