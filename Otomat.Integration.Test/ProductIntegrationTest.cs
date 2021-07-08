using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Otomat.Integration.Test
{
    public class ProductIntegrationTest
    {
        [Fact]
        public async Task GetProductList()
        {
            // Arrange
            using var httpClient = new TestClientProvider().HttpClient;
             
            // Act
            var response = await httpClient.GetAsync($"/api/products");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
