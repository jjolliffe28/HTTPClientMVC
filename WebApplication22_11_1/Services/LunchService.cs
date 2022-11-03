using WebApplication22_11_1.Helpers;
using WebApplication22_11_1.Models;
using WebApplication22_11_1.Services.Interfaces;


namespace WebApplication22_11_1.Services
{
    public class LunchService : ILunchService
    {
        private readonly HttpClient _client;
        public const string BasePath = "/api/Lunch/";

        public LunchService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<Lunch>> FindAll()
        {
            var responseGet = await _client.GetAsync(BasePath);

            var response = await responseGet.ReadContentAsync<List<Lunch>>();

            return response;
        }

        public async Task<Lunch> FindOne(int id)
        {
            var request = BasePath + id.ToString();
            var responseGet = await _client.GetAsync(request);

            var response = await responseGet.ReadContentAsync<Lunch>();

            var lunch = new Lunch(response.Id, response.CuisineId, response.RestaurantId, response.isHot, response.cost, response.isDelicious, response.isHealthy);

            return lunch;
        }
    }
}

