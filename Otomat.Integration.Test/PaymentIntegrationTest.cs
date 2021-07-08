using FluentAssertions;
using Newtonsoft.Json;
using Otomat.Business.Enum;
using Otomat.Business.Models;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Otomat.Integration.Test
{
    public class PaymentIntegrationTest
    {
        [Fact]
        public async Task GetPayments()
        {
            // Arrange
            using var httpClient = new TestClientProvider().HttpClient;
             
            // Act
            var response = await httpClient.GetAsync($"/api/payments");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }


        [Fact]
        public async Task Pay()
        {

            ByProductDto byProductDto = new ByProductDto()
            {
                Money = 10,
                PaymentOption = Business.Enum.PaymentOption.WithBaknote,
                Product = new ProductDto()
                {
                    Id = 1,
                    Name = "Kahve",
                    Price = 7,
                    ProductType = new ProductType() { DrinkOption = 1, Name = "icecek" },
                    Quantity = 1
                },
                Quantity = 1,
            };

            string json = JsonConvert.SerializeObject(byProductDto);

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");


            using var httpClient = new TestClientProvider().HttpClient;
            // Act
            var response = await httpClient.PostAsync($"/api/payments", httpContent);
            
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

       
        

}
}
