namespace MyAPI.Models
{
    //It will solely focus of the methods for CRUD operations
    public interface IUserRepository
    {
        //Declare the functionalities/operations that can be
        //performed on User entity(table)

        //making all the methods asynchronous
        Task<User> GetUserByIdAsync(int userId);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int userId);

        /*
         User GetUserById(int userId);
        IEnumerable<User> GetAllUsers();
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
        */
    }
}
