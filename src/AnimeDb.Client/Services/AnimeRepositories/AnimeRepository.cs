using AnimeDb.Client.Models;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AnimeDb.Client.Services.AnimeRepositories
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly RestClient _client;

        public AnimeRepository(IConfiguration configuration) 
        {
            string baseUrl = configuration["Api:Url"] ?? "";
            _client = new RestClient(baseUrl);

            _client.AddDefaultHeader("X-RapidAPI-Key", configuration["Api:Headers:X-RapidAPI-Key"] ?? "");
            _client.AddDefaultHeader("X-RapidAPI-Host", configuration["Api:Headers:X-RapidAPI-Host"] ?? "");
        }

        public async Task<Anime> GetById(string id)
        {
            var request = new RestRequest("anime/by-id/{id}")
                                .AddUrlSegment("id", id);

            RestResponse<Anime> response = await _client.ExecuteAsync<Anime>(request);
            if (!response.IsSuccessful)
                return new Anime();

            return response.Data ?? new Anime();
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            var request = new RestRequest("genre");

            RestResponse<IEnumerable<Genre>> response = await _client.ExecuteAsync<IEnumerable<Genre>>(request);
            if (!response.IsSuccessful)
                return Enumerable.Empty<Genre>();

            return response.Data ?? Enumerable.Empty<Genre>();
        }
    }
}
