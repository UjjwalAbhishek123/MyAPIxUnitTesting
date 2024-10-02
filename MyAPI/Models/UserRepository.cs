
namespace MyAPI.Models
{
    //It will solely focus on implementing methods of
    //IUserRepository for CRUD operations
    public class UserRepository : IUserRepository
    {
        //creating private List of users
        private readonly List<User> _users;
        public UserRepository()
        {
            //simulating data source
            _users = new List<User>()
            {
                new User{ Id = 1, Name = "John Doe", Email = "john@example.com" },
                new User{ Id = 2, Name = "Jane Smith", Email = "jane@example.com" },
                new User{ Id = 3, Name = "Jaden Smith", Email = "jaden@example.com" },
                new User{ Id = 4, Name = "Steve Dow", Email = "steve@example.com" }
            };
        }

        //getting particular user by Id
        public User GetUserById(int userId)
        {
            return _users.FirstOrDefault(u => u.Id == userId);
        }

        //getting all users
        public IEnumerable<User> GetAllUsers()
        {
            //returning all the users, actual data
            return _users;
        }

        public void AddUser(User user)
        {
            // Automatically assign the next available ID
            if (_users.Count > 0)
            {
                user.Id = _users.Max(u => u.Id) + 1; // Set ID to the highest current ID + 1
            }
            else
            {
                user.Id = 1; // First user
            }

            //adding/creating new user
            _users.Add(user);
        }

        public void UpdateUser(User user)
        {
            var existingUser = GetUserById(user.Id);
            if(existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
            }
        }

        public void DeleteUser(int userId)
        {
            var user = GetUserById(userId);
            if (user != null)
            {
                _users.Remove(user);
            }
        }
    }
}
