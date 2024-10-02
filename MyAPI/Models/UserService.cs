
namespace MyAPI.Models
{
    public class UserService : IUserService
    {
        //creating IUserRepository object that will return
        //Data to Service class
        //after database operations
        private readonly IUserRepository _userRepository;

        //initializing private field through constructor 
        //which will be used in service methods
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        //public User GetUserById(int userId)
        //{
        //    return _userRepository.GetUserById(userId);
        //}

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            //returning data from repository
            return await _userRepository.GetAllUsersAsync();
        }

        //public IEnumerable<User> GetAllUsers()
        //{
        //    //returning data from repository
        //    return _userRepository.GetAllUsers();
        //}

        public async Task AddUserAsync(User user)
        {
            await _userRepository.AddUserAsync(user);
        }

        //public void AddUser(User user)
        //{
        //    _userRepository.AddUser(user);
        //}

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateUserAsync(user);
        }

        //public void UpdateUser(User user)
        //{
        //    _userRepository.UpdateUser(user);
        //}

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }

        //public void DeleteUser(int userId)
        //{
        //    _userRepository.DeleteUser(userId);
        //}
    }
}
