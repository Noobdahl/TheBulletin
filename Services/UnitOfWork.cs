using TheBulletin.Data;

namespace TheBulletin.Services
{
    internal class UnitOfWork
    {
        private readonly AppDbContext _context;


        private UserRepository? _userRepo;
        private ChatRepository? _chatRepo;



        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public UserRepository UserRepo
        {
            get
            {
                if (_userRepo == null)
                {
                    _userRepo = new UserRepository(_context);
                }
                return _userRepo;
            }
        }

        public ChatRepository ChatRepo
        {
            get
            {
                if (_chatRepo == null)
                {
                    _chatRepo = new ChatRepository(_context);
                }
                return _chatRepo;
            }
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public async void SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
