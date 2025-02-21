using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests.Endspoints
{
    public class EndpointClientHandler
    {
        protected readonly HttpClient _client;
        public EndpointClientHandler()
        {
            var factory = new WebApplicationFactory<Program>();
            _client = factory.CreateClient();
        }
    }
}
