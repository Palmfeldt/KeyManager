using System.Net.Mime;
using System.Text;
using System.Text.Json;
using KeyManager.Domain.Models;
namespace KeyManager.Tests.Endspoints
{
    [TestClass]
    public sealed class Key_Tests : EndpointClientHandler
    {
        [TestMethod]
        public async void AddKey()
        {
            var key = new Key
            {
                KeyIdentifier = "TestKey"
            };
            var jsonString = JsonSerializer.Serialize(key);
            var content = new StringContent(jsonString, Encoding.UTF8, MediaTypeNames.Application.Json);
            var result = await _client.PostAsync("/KeyManagement", content);

            Assert.IsFalse(false);
        }

        [TestMethod]
        public void RemoveKey()
        {
            //var result = await _client.GetAndDeserializeAsync<ICollection<Key>>(route);
            Assert.IsFalse(true);
        }
    }
}
