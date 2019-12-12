using Arsenal.Application;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Arsenal.Test.Application.Controllers
{
    public abstract class ContollerTestSetup
    {
        protected readonly HttpClient _client;

        public ContollerTestSetup()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());

            _client = server.CreateClient();
        }
    }
}