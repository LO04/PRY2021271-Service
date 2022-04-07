using System;
using Moq;
using NUnit.Framework;
using Montrac.Domain.Models;
using Montrac.Domain.Repository;
using Montrac.Services;

namespace Montrac.UnitTests
{
    public class UserTests
    {
        //private static Mock<IRepository<User>> GetDefaultIUserRepositoryInstance() => new();
        //private static Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance() => new();
        
        //[Test]
        //public void UserRegisters_WithFutureBirthDate_ReturnsErrorMessage()
        //{
        //    // Arrange
        //    var userRepository = GetDefaultIUserRepositoryInstance();
        //    var unitOfWork = GetDefaultIUnitOfWorkInstance();
        //    var userService = new UserService(userRepository.Object, unitOfWork.Object);
          
        //    // Act
        //    var user = new User();
        //    var result = userService.CreateUser(user).Result;

        //    // Assert
        //    Assert.AreEqual(result.Message, "User birthday cannot be in the future");
        //}
    }
}