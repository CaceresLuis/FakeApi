using FakeApi.DTO;
using FakeApi.DTO.V2;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace FakeApi.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private const string FakeStore = "https://fakestoreapi.com/products";
        private readonly HttpClient _httpClient;

        public ProductsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [MapToApiVersion("2.0")]
        [HttpGet(Name = "GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            //_httpClient.DefaultRequestHeaders.Clear();
            //_httpClient.DefaultRequestHeaders.Add("app-id")

            Stream getData = await _httpClient.GetStreamAsync(FakeStore);
            ValueTask<List<Products>?> products = JsonSerializer.DeserializeAsync<List<Products>>(getData); //Get array        

            List<Products>? data = products.Result;
            List<Products>? response = new();

            foreach (Products item in data)
            {
                Random num = new();
                Rating rating = new Rating { Count = num.Next(1, 100), Rate = num.Next(1, 5) };
                item.Rating = rating;
                item.InternalId = Guid.NewGuid();
                response.Add(item);
            }


            return Ok(response);
        }
    }
}
