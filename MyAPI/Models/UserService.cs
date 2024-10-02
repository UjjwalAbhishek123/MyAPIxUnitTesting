
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

        public User GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }

        public IEnumerable<User> GetAllUsers()
        {
            //returning data from repository
            return _userRepository.GetAllUsers();
        }

        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
        }

        public void DeleteUser(int userId)
        {
            _userRepository.DeleteUser(userId);
        }
    }
}
