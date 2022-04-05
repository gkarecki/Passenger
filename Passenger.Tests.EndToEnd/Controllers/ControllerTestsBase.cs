using System.IO;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Passenger.Api;

namespace Passenger.Tests.EndToEnd.Controllers
{
    public abstract class ControllerTestsBase
    {
        protected readonly TestServer Server;
        protected readonly HttpClient Client;

        // public IWebHostBuilder CreateWebHostBuilder()
        // {
        //     var config = new ConfigurationBuilder()
        //         .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //         .Build();

        //     var host = new WebHostBuilder()
        //         .UseConfiguration(config)
        //         .UseStartup<Startup>() // Point to the test startup first
        //         .UseSetting(WebHostDefaults.ApplicationKey, typeof(Startup).GetTypeInfo().Assembly.GetName().Name); // Set the "right" application after the startup's been registerted

        //     return host;
        // }
        // protected ControllerTestsBase()
        // {
        //     Server = new TestServer(CreateWebHostBuilder()              
        //         .UseStartup<Startup>());
        //     Client = Server.CreateClient();
        // }

        protected ControllerTestsBase()
        {
            Server = new TestServer(new WebHostBuilder() 
                .UseEnvironment("Development") 
                .UseContentRoot(Directory.GetCurrentDirectory()) 
                .UseConfiguration(new ConfigurationBuilder() 
                    .SetBasePath(Directory.GetCurrentDirectory()) 
                    .AddJsonFile("appsettings.json") 
                    .Build()) 
                .UseStartup<Startup>()); 
                
                Client = Server.CreateClient();
        }

        protected static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}