using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.DTO;
// using Xunit;

namespace Passenger.Tests.EndToEnd.Controllers
{
    [TestFixture]
    public class UsersControllerTests : ControllerTestsBase
    {
        // [Fact]
        [Test]
        public async Task given_valid_email_user_shuld_exists()
        {
            // Act
            var email = "user1@test.com";
            var user = await GetUserAsync(email);
            user.Email.Should().EndWithEquivalent(email);
            // Assert.Equal(user.Email, email);
        }

        // [Fact]
        [Test]
        public async Task given_valid_email_user_shuld_not_exists()
        {
            // Act
            var email = "user100@email.com";
            var response = await Client.GetAsync($"/users/{email}");
            
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NotFound);
        }
        // [Fact]
        [Test]
        public async Task given_unique_email_user_shuld_be_created()
        {
            var command = new CreateUser
            {
                Email = "test@email.com",
                Username = "test",
                Password = "secret",
                Role = "admin"
            };
            var payload = GetPayload(command);
            var response = await Client.PostAsync("users", payload);
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().Should().BeEquivalentTo($"users/{command.Email}");

            var user = await GetUserAsync(command.Email);
            user.Email.Should().EndWithEquivalent(command.Email);
        }

        private async Task<UserDTO> GetUserAsync(string email)
        {
            var response = await Client.GetAsync($"/users/{email}");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserDTO>(responseString);
        }
    }
}