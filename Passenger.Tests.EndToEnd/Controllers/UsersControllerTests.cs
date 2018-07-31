using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Passenger.Api;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.DTO;
using Xunit;

namespace Passenger.Tests.EndToEnd.Controllers
{
    public class UsersControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public UsersControllerTests()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task given_valid_email_user_shuld_exists()
        {
            // Act
            var email = "user1@email.com";
            var user = await GetUserAsync(email);
            user.Email.Should().EndWithEquivalent(email);
            // Assert.Equal(user.Email, email);
        }

        [Fact]
        public async Task given_valid_email_user_shuld_not_exists()
        {
            // Act
            var email = "user100@email.com";
            var response = await _client.GetAsync($"/users/{email}");
            
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NotFound);
        }
        [Fact]
        public async Task given_unique_email_user_shuld_be_created()
        {
            var request = new CreateUser
            {
                Email = "test@email.com",
                Username = "test",
                Password = "secret",
                FullName = "testfull"
            };
            var payload = GetPayload(request);
            var response = await _client.PostAsync("users", payload);
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().Should().BeEquivalentTo($"users/{request.Email}");

            var user = await GetUserAsync(request.Email);
            user.Email.Should().EndWithEquivalent(request.Email);
        }

        private static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private async Task<UserDTO> GetUserAsync(string email)
        {
            var response = await _client.GetAsync($"/users/{email}");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserDTO>(responseString);
        }
    }
}