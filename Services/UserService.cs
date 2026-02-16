using Miniyou.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace MiniYou_App.Services
{
    internal class UserService
    {
        private HttpClient _httpClient;

        public UserService()
        {
            _httpClient = new HttpClient
            { BaseAddress = new Uri("http://127.0.0.1:8000/api/") };
        }
        public async Task<List<User>> GetUser()
        {
            var response = await _httpClient.GetAsync("users/");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<User>>() ?? new List<User>();
            }
            else
            {
                return new List<User>();
            }
        }
    }
}