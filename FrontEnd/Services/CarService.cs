using System.Net.Http.Json;
using FrontEnd.Models;

namespace FrontEnd.Services
{
    public class CarService
    {
        private readonly HttpClient _http;

        public CarService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Car>> GetCarsAsync()
        {
            return await _http.GetFromJsonAsync<List<Car>>("/Cars"); // relative!
        }
    }
}
