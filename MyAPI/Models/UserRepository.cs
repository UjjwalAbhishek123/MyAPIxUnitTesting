﻿
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
        public async Task<User> GetUserByIdAsync(int userId)
        {
            //Simulate the async operation using Task.Delay
            await Task.Delay(TimeSpan.FromMilliseconds(1));
            return _users.FirstOrDefault(u => u.Id == userId);
        }

        //public User GetUserById(int userId)
        //{
        //    return _users.FirstOrDefault(u => u.Id == userId);
        //}

        //getting all users
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            //Simulate the async operation using Task.Delay
            await Task.Delay(TimeSpan.FromMilliseconds(1));

            //returning all the users, actual data
            return _users;
        }

        //public IEnumerable<User> GetAllUsers()
        //{
        //    //returning all the users, actual data
        //    return _users;
        //}

        public async Task AddUserAsync(User user)
        {
            // Simulate the async operation using Task.Delay
            await Task.Delay(TimeSpan.FromMilliseconds(1));

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

        //public void AddUser(User user)
        //{
        //    // Automatically assign the next available ID
        //    if (_users.Count > 0)
        //    {
        //        user.Id = _users.Max(u => u.Id) + 1; // Set ID to the highest current ID + 1
        //    }
        //    else
        //    {
        //        user.Id = 1; // First user
        //    }

        //    //adding/creating new user
        //    _users.Add(user);
        //}

        public async Task UpdateUserAsync(User user)
        {
            //Simulate the async operation using Task.Delay
            await Task.Delay(TimeSpan.FromMilliseconds(1));
            
            var existingUser = await GetUserByIdAsync(user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
            }
        }

        //public void UpdateUser(User user)
        //{
        //    var existingUser = GetUserById(user.Id);
        //    if(existingUser != null)
        //    {
        //        existingUser.Name = user.Name;
        //        existingUser.Email = user.Email;
        //    }
        //}

        public async Task DeleteUserAsync(int userId)
        {
            //Simulate the async operation using Task.Delay
            await Task.Delay(TimeSpan.FromMilliseconds(1));
            
            var user = await GetUserByIdAsync(userId);
            if (user != null)
            {
                _users.Remove(user);
            }
        }

        //public void DeleteUser(int userId)
        //{
        //    var user = GetUserById(userId);
        //    if (user != null)
        //    {
        //        _users.Remove(user);
        //    }
        //}
    }
}
