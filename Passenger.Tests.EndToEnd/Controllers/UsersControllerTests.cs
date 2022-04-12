using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Passenger.Api;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.DTO;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Passenger.Tests.EndToEnd.Controllers
{
    public class UsersControllerTests : ControllerTestsBase
    {
        public UsersControllerTests(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task given_valid_email_user_should_exists()
        {
            // Arrange
            var email = "user1@test.com";

            //Act
            var user = await GetUserAsync(email);

            //Assert
            user.Email.Should().EndWithEquivalent(email);
        }

        [Fact]
        public async Task given_valid_email_user_should_not_exists()
        {
            // Arrange
            var email = "user100@email.com";
            
            // Act
            var response = await _client.GetAsync($"api/users/{email}");
            
            //Assert
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task given_unique_email_user_should_be_created()
        {
            // Arrange
            var rnd = new Random();
            var command = new CreateUser
            {
                Email = $"test{rnd.Next()}@email.com",
                Username = "testUser",
                FullName = "testFullName",
                Password = "secret",
                Role = "user"
            };
            var payload = GetPayload(command);

            // Act
            var response = await _client.PostAsync("api/users", payload);
            var user = await GetUserAsync(command.Email);

            //Assert
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().Should().BeEquivalentTo($"api/users/{command.Email}");
            user.Email.Should().EndWithEquivalent(command.Email);
        }

        private async Task<UserDTO> GetUserAsync(string email)
        {
            var response = await _client.GetAsync($"api/users/{email}");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserDTO>(responseString);
        }
    }
}