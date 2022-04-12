using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Passenger.Api;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Passenger.Tests.EndToEnd.Controllers
{
    public abstract class ControllerTestsBase : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly List<Type> _controllerTypes;
        private readonly WebApplicationFactory<Startup> _factory;
        protected readonly HttpClient _client;

        protected ControllerTestsBase(WebApplicationFactory<Startup> factory)
        {
            //_controllerTypes = typeof(Startup)
            //    .Assembly
            //    .GetTypes()
            //    .Where(t => t.IsSubclassOf(typeof(ApiControllerBase)))
            //    .ToList();

            //_factory = factory.WithWebHostBuilder(builder =>
            //{
            //    builder.ConfigureServices(services =>
            //    {
            //        _controllerTypes.ForEach(c => services.AddScoped(c));
            //    });
            //});

            _client = factory.CreateClient();
        }

        //[Fact]
        //[Fact(Skip="TODO: add dependencies")]
        //public void configure_services_for_controllers_registers_all_dependencies()
        //{
        //    //arrange
        //    var scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
        //    using var scope = scopeFactory.CreateScope();

        //    // assert
        //    _controllerTypes.ForEach(t =>
        //    {
        //        var controller = scope.ServiceProvider.GetService(t);
        //        controller.Should().NotBeNull();
        //    });
        //}

        protected static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}