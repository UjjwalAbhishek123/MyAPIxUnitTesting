using Moq;
using MyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyAPI.xUnitTests
{
    public class UserServiceTests
    {
        //instance of service being tested
        private readonly UserService _demoService;

        //Mock instance of repository
        //Moq object will simulate the behavior of IUserRepository interface without relying on a real implementation
        private readonly Mock<IUserRepository> _mockRepository;

        //Constructor to initialize mock repository and the service
        public UserServiceTests()
        {
            _mockRepository = new Mock<IUserRepository>();
            _demoService = new UserService(_mockRepository.Object);

            /*
             * _mockRepository.Object:
             * This is the actual mock object that implements the IUserRepository interface. 
             * When you create a mock using Moq, you access the underlying object with the .Object property. 
             * This object will behave according to the setups you've defined on the mock.
            */
        }

        // Test to verify that GetUserById returns the correct user
        //[Fact]
        //public void GetUserById_ReturnsUser()
        //{
        //    //Arrange
        //    var userId = 1;
        //    var expectedUser = new User { Id = 1, Name = "John Doe", Email = "john@example.com" };

        //    //Setup the mock to return the expected user when GetUserById is called
        //    _mockRepository.Setup(repo => repo.GetUserById(userId)).Returns(expectedUser);

        //    //ACT
        //    var result = _demoService.GetUserById(userId);

        //    //Assert
        //    Assert.NotNull(result); // Check that the result is not null
        //    Assert.Equal(expectedUser.Id, result.Id); // Check that the ID is correct
        //    Assert.Equal(expectedUser.Name, result.Name); //// Check that the name is correct
        //    Assert.Equal(expectedUser.Email, result.Email); // Check that the email is correct
        //}

        [Theory]
        [MemberData(nameof(GetUserByIdData))]
        public async Task GetUserByIdAsync_ReturnsExpectedResult(int userId, User expectedUser)
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetUserByIdAsync(userId)).ReturnsAsync(expectedUser);
            // Act
            var result = await _demoService.GetUserByIdAsync(userId);
            // Assert
            if (expectedUser != null)
            {
                Assert.NotNull(result);
                Assert.Equal(expectedUser.Id, result.Id);
                Assert.Equal(expectedUser.Name, result.Name);
                Assert.Equal(expectedUser.Email, result.Email);
            }
            else
            {
                Assert.Null(result);
            }
        }

        // Data provider for GetUserByIdAsync test cases
        public static IEnumerable<object[]> GetUserByIdData =>
            new List<object[]>
            {
                new object[] { 1, new User { Id = 1, Name = "John Doe", Email = "john@example.com" } },
                new object[] { 99, null }
            };

        // Test to verify that GetUserById returns null when the user is not found
        //[Fact]
        //public void GetUserById_ReturnsNullWhenUserNotFound()
        //{
        //    //arrange
        //    var userId = 99;
        //    _mockRepository.Setup(repo => repo.GetUserByIdAsync(userId)).Returns((User)null);

        //    //act
        //    var result = _demoService.GetUserById(userId);

        //    //assert
        //    Assert.Null(result); // Check that the result is null
        //}

        // Test to verify that GetAllUsers returns a list of users
        //[Fact]
        //public void GetAllUsers_ReturnsListOfUsers()
        //{
        //    // Arrange
        //    var expectedUsers = new List<User>
        //    {
        //        new User { Id = 1, Name = "John Doe", Email = "john@example.com" },
        //        new User { Id = 2, Name = "Jane Smith", Email = "jane@example.com" },
        //        new User{ Id = 3, Name = "Jaden Smith", Email = "jaden@example.com" },
        //        new User{ Id = 4, Name = "Steve Dow", Email = "steve@example.com" }
        //    };
        //    _mockRepository.Setup(repo => repo.GetAllUsers()).Returns(expectedUsers);

        //    //Act
        //    var result = _demoService.GetAllUsers();

        //    //Assert
        //    Assert.NotNull(result); //check that result is not null

        //    //check that count of users is correct
        //    Assert.Equal(expectedUsers.Count, result.Count());
        //}

        [Fact]
        public async Task GetAllUsersAsync_ReturnsListOfUsers()
        {
            // Arrange
            var expectedUsers = new List<User>
            {
                new User { Id = 1, Name = "John Doe", Email = "john@example.com" },
                new User { Id = 2, Name = "Jane Smith", Email = "jane@example.com" }
            };
            
            _mockRepository.Setup(repo => repo.GetAllUsersAsync()).ReturnsAsync(expectedUsers);
            
            // Act
            var result = await _demoService.GetAllUsersAsync();
            
            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedUsers.Count, result.Count());
        }

        //Test to verify that AddUser calls the repository's AddUser method
        //[Fact]
        //public void AddUser_CallsRepository()
        //{
        //    //Arrange
        //    var newUser = new User { Id = 5, Name = "Sam Wilson", Email = "sam@example.com" };

        //    //act
        //    _demoService.AddUser(newUser);

        //    //assert
        //    // Check that AddUser was called once
        //    _mockRepository.Verify(repo => repo.AddUser(newUser), Times.Once);

        //}

        [Fact]
        public async Task AddUserAsync_CallsRepository()
        {
            // Arrange
            var newUser = new User { Id = 5, Name = "Sam Wilson", Email = "sam@example.com" };

            // Act
            await _demoService.AddUserAsync(newUser);

            // Assert
            _mockRepository.Verify(repo => repo.AddUserAsync(newUser), Times.Once);
        }

        // Test to verify that UpdateUser calls the repository's UpdateUser method
        //[Fact]
        //public void UpdateUser_CallsRepository()
        //{
        //    // Arrange
        //    var updatedUser = new User { Id = 1, Name = "John Updated", Email = "john.updated@example.com" };

        //    // Act
        //    _demoService.UpdateUser(updatedUser);

        //    // Assert
        //    // Check that UpdateUser was called once
        //    _mockRepository.Verify(repo => repo.UpdateUser(updatedUser), Times.Once);
        //}

        [Fact]
        public async Task UpdateUserAsync_CallsRepository()
        {
            // Arrange
            var updatedUser = new User { Id = 1, Name = "John Updated", Email = "john.updated@example.com" };

            // Act
            await _demoService.UpdateUserAsync(updatedUser);

            // Assert
            _mockRepository.Verify(repo => repo.UpdateUserAsync(updatedUser), Times.Once);
        }

        // Test to verify that DeleteUser calls the repository's DeleteUser method
        //[Fact]
        //public void DeleteUser_CallsRepository()
        //{
        //    // Arrange
        //    var userId = 1;

        //    // Act
        //    _demoService.DeleteUser(userId);

        //    // Assert
        //    // Check that DeleteUser was called once
        //    _mockRepository.Verify(repo => repo.DeleteUser(userId), Times.Once);
        //}

        [Fact]
        public async Task DeleteUserAsync_CallsRepository()
        {
            // Arrange
            var userId = 1;

            // Act
            await _demoService.DeleteUserAsync(userId);

            // Assert
            _mockRepository.Verify(repo => repo.DeleteUserAsync(userId), Times.Once);
        }
    }
}
