using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Passenger.Api;
using Passenger.Infrastructure.Commands.Users;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Passenger.Tests.EndToEnd.Controllers
{
    public class AccountControllerTest : ControllerTestsBase
    {
        public AccountControllerTest(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task given_valid_current_and_new_password_it_should_be_changed()
        {
            // Arrange
            var command = new ChangeUserPassword
            {
                CurrentPassword = "secret",
                NewPassword = "secret2"
            };

            //Act
            var payload = GetPayload(command);
            var response = await _client.PutAsync("api/account/password", payload);

            //Assert
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NoContent);
        }
    }
}