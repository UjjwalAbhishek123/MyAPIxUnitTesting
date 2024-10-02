namespace MyAPI.Models
{
    public interface IUserService
    {
        //Declare the functionalities/operations that can be
        //called by Service class for implementation
        //when Controller calls service class

        //making methods asynchronous
        Task<User> GetUserByIdAsync(int userId);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int userId);
    }

    //User GetUserById(int userId);
    //IEnumerable<User> GetAllUsers();
    //void AddUser(User user);
    //void UpdateUser(User user);
    //void DeleteUser(int userId);
}
