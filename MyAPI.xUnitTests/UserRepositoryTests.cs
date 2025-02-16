﻿using MyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAPI.xUnitTests
{
    public class UserRepositoryTests
    {
        private readonly UserRepository _userRepository;

        //constructor initializes thr UserRepository instance
        public UserRepositoryTests()
        {
            _userRepository = new UserRepository();
        }

        /*
         * The Fact attribute in xUnit is used to denote a method as a test method. 
         * When we decorate a method with the Fact attribute, xUnit knows
         * that this method should be executed as a test case. 
         * A test method marked with
         * Fact does not take any parameters.
         */

        // Combined test to verify that GetUserById returns the correct user or null if not found
        [Theory]
        [InlineData(1, true)]  // User with ID 1 exists
        [InlineData(99, false)] // User with ID 99 does not exist
        public async Task GetUserById_ReturnsExpectedResult(int userId, bool userExists)
        {
            // Act
            var result = await _userRepository.GetUserByIdAsync(userId);
            
            // Assert
            if (userExists)
            {
                Assert.NotNull(result);
                Assert.Equal(userId, result.Id);
            }
            else
            {
                Assert.Null(result);
            }
        }

        //creating Test Methods
        //test to verify that GetUserById returns the correct user
        //[Fact]
        //public void GetUserById_ReturnsCorrectUser()
        //{
        //    //Arrange => Setting up any necessary data before performing actions
        //    var userId = 1;

        //    //Act => Performing Action to be tested
        //    var result = _userRepository.GetUserById(userId);

        //    //Assert => Verifying that action produced expected results
        //    //Check that result is not null
        //    Assert.NotNull(result);

        //    //check that ID of returned user is correct
        //    Assert.Equal(userId, result.Id);
        //}

        // Test to verify that GetUserById returns null
        // when the user is not found
        //[Fact]
        //public void GetUserById_ReturnsNullWhenUserNotFound()
        //{
        //    //Arrange
        //    //assume this id doesn't exists
        //    var userId = 99;

        //    //Act
        //    var result = _userRepository.GetUserById(userId);
        //}

        [Fact]
        public async Task GetAllUsersAsync_ReturnsAllUsers()
        {
            // Act
            var result = await _userRepository.GetAllUsersAsync();
            
            // Assert
            Assert.NotNull(result);
            Assert.Equal(4, result.Count()); // Assuming there are 2 users initially
        }

        //test to verify that GetAllUsers returns all users
        //[Fact]
        //public void GetAllUsers_ReturnsAllUsers()
        //{
        //    //act
        //    var result = _userRepository.GetAllUsers();

        //    //assert
        //    //check that result is not null
        //    Assert.NotNull(result);

        //    //assuming there are 4 users, check that count is correct
        //    Assert.Equal(4, result.Count());
        //}

        //Test to verify that AddUser adds user correctly
        //[Fact]
        //public void AddUser_AddsUserCorrectly()
        //{
        //    //Arrange
        //    var random = new Random();

        //    var name = $"User{random.Next(1, 1000)}"; //generate random name

        //    var email = $"{name.ToLower()}@example.com"; //generate a corresponding email

        //    var newUser = new User { Name = name, Email = email };

        //    //Act
        //    _userRepository.AddUser(newUser);
        //    var result = _userRepository.GetUserById(newUser.Id);

        //    //Assert
        //    Assert.NotNull(result); // Check that the user was added and returned
        //    Assert.NotEqual(0, result.Id); // Ensure the ID is not zero
        //    Assert.Equal(newUser.Name, result.Name); // Check that the name is correct
        //    Assert.Equal(newUser.Email, result.Email); // Check that the email is correct

        //}

        [Fact]
        public async Task AddUserAsync_AddsUserCorrectly()
        {
            //Arrange
            var newUser = new User { Id = 5, Name = "Sam Wilson", Email = "sam@example.com" };
            
            // Act
            await _userRepository.AddUserAsync(newUser);
            
            var result = await _userRepository.GetUserByIdAsync(newUser.Id);
            
            // Assert
            Assert.NotNull(result);
            Assert.Equal(newUser.Id, result.Id);
            Assert.Equal(newUser.Name, result.Name);
            Assert.Equal(newUser.Email, result.Email);

        }

        //[Fact]
        //public void UpdateUser_UpdatesUserCorrectly()
        //{
        //    //Arrange
        //    //Get random existing user
        //    var existingUser = _userRepository.GetAllUsers().FirstOrDefault(); // Get any existing user

        //    Assert.NotNull(existingUser); // Ensure that we have a user to update

        //    // Generate a unique name and derive the email from it
        //    var newName = $"NewName-{Guid.NewGuid()}";
        //    var newEmail = $"{newName.ToLower().Replace(" ", ".")}@example.com"; // Generate a corresponding email

        //    var updatedUser = new User()
        //    {
        //        Id = existingUser.Id, // Use the existing user's ID
        //        Name = newName, // Set the dynamically generated name
        //        Email = newEmail // Set the corresponding email
        //    };

        //    //Act
        //    _userRepository.UpdateUser(updatedUser);
        //    var result = _userRepository.GetUserById(existingUser.Id); //Fetch user again

        //    //Assert
        //    Assert.NotNull(result); //check that the user was found
        //    Assert.Equal(updatedUser.Name, result.Name); // Check that the name was updated
        //    Assert.Equal(updatedUser.Email, result.Email); //Check that email was updated
        //}

        [Fact]
        public async Task UpdateUserAsync_UpdatesUserCorrectly()
        {
            // Arrange
            var updatedUser = new User { Id = 1, Name = "John Updated", Email = "john.updated@example.com" };
            
            // Act
            await _userRepository.UpdateUserAsync(updatedUser);
            var result = await _userRepository.GetUserByIdAsync(updatedUser.Id);
            
            // Assert
            Assert.NotNull(result);
            Assert.Equal(updatedUser.Name, result.Name);
            Assert.Equal(updatedUser.Email, result.Email);
        }

        //[Fact]
        //public void DeleteUser_DeletesUserCorrectly()
        //{
        //    // Arrange
        //    var userId = 1;

        //    // Act
        //    _userRepository.DeleteUser(userId);
        //    var result = _userRepository.GetUserById(userId);

        //    // Assert
        //    Assert.Null(result); // Check that the user was deleted and cannot be found
        //}

        [Fact]
        public async Task DeleteUserAsync_DeletesUserCorrectly()
        {
            // Arrange
            var userId = 1;

            // Act
            await _userRepository.DeleteUserAsync(userId);
            var result = await _userRepository.GetUserByIdAsync(userId);

            // Assert
            Assert.Null(result);
        }
    }
}
