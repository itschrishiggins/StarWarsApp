using System.Net.Http;
using System.Threading.Tasks;

namespace StarWarsApp_API.Services
{
    public class StarWarsService
    {
        private readonly HttpClient _httpClient; // HttpClient instance for making API requests

        public StarWarsService(HttpClient httpClient)
        {
            _httpClient = httpClient; // Constructor receives HTTP Client object
        }

        public async Task<string> GetCharacters()
        {
            var response = await _httpClient.GetAsync("https://swapi.dev/api/people/"); // Making GET request to SWAPI
            response.EnsureSuccessStatusCode(); // Throw exception if unsuccessful
            return await response.Content.ReadAsStringAsync(); // Read response content as a string
        }

        public async Task<string> SearchCharacters(string name)
        {
            var response = await _httpClient.GetAsync($"https://swapi.dev/api/people/?search={name}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetCharacterDetail(int id)
        {
            var response = await _httpClient.GetAsync($"https://swapi.dev/api/people/{id}/");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
