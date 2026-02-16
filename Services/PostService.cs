using Miniyou.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;

namespace MiniYou_App.Services
{
    internal class PostService
    {
        private HttpClient _httpClient;

        public PostService()
        {
            _httpClient = new HttpClient
            { BaseAddress = new Uri("http://127.0.0.1:8000/api/") };
        }
        public async Task<List<Post>> GetPosts()
        {
            var response = await _httpClient.GetAsync("posts/");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<Post>>() ?? new List<Post>();
            }
            else 
            {
                return new List<Post>();
            }
        }
    }
}
