
using System.Threading.Tasks;
using FluentAssertions;
// using Xunit;
using Moq;
using Passenger.Core.Repositories;
using AutoMapper;
using Passenger.Infrastructure.Services;
using Passenger.Core.Domain;
using NUnit.Framework;

namespace Passenger.Tests.Services
{
    [TestFixture]
    public class UserServiceTests
    {
        // [Fact]
        [Test]
        public async Task register_async_should_invoke_add_async_on_repository()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var encrypterMock = new Mock<IEncrypter>();
            var mapperMock = new Mock<IMapper>();
            encrypterMock.Setup(x => x.GetSalt(It.IsAny<string>())).Returns("hash");
            encrypterMock.Setup(x => x.GetHash(It.IsAny<string>(),It.IsAny<string>())).Returns("salt");
            var userService = new UserService(userRepositoryMock.Object,encrypterMock.Object, mapperMock.Object);

            await userService.RegisterAsync("user@email.com", "user", "fullName", "secret");

            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }

        // [Fact]
        [Test]
        public async Task when_callig_get_async_and_user_exists_it_should_invoke_user_repository_get_async()
        {
            var encrypterMock = new Mock<IEncrypter>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepositoryMock.Object,encrypterMock.Object, mapperMock.Object);
            await userService.GetAsync("user1@rmail.com");

            var user = new User("user1@rmail.com", "user1", "fullName", "secret", "salt");

            userRepositoryMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(user);
            userRepositoryMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once());
            
        }
        
        // [Fact]
        [Test]
        public async Task when_calling_get_async_and_user_does_not_exist_it_should_invoke_user_repository_get_async()
        {
            var encrypterMock = new Mock<IEncrypter>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepositoryMock.Object,encrypterMock.Object, mapperMock.Object);
            await userService.GetAsync("user1@email.com");

            userRepositoryMock.Setup(x => x.GetAsync("user@email.com")).ReturnsAsync(() => null);
            userRepositoryMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once());
        }
    }
}