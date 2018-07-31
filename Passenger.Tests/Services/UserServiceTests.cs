
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Moq;
using Passenger.Core.Repositories;
using AutoMapper;
using Passenger.Infrastructure.Services;
using Passenger.Core.Domain;

namespace Passenger.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task register_async_should_invoke_add_async_on_repository()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            await userService.RegisterAsync("user@email.com", "user", "fullName", "secret");

            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }
    }
}