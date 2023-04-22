using AnimeDb.Client.Models;
using MaterialDesignColors;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AnimeDb.Client.Services.QueryBuilderService
{
    public class QueryBuilder : IQueryBuilder
    {
        private readonly IRestClient _client;
        private RestRequest _request;

        public QueryBuilder(IConfiguration configuration)
        {
            string baseUrl = configuration["Api:Url"] ?? "";
            _client = new RestClient(baseUrl)
                            .AddDefaultHeader("X-RapidAPI-Key", configuration["Api:Headers:X-RapidAPI-Key"] ?? "")
                            .AddDefaultHeader("X-RapidAPI-Host", configuration["Api:Headers:X-RapidAPI-Host"] ?? "");

            _request = new RestRequest("anime", Method.Get);
        }

        public IQueryBuilder AddGenre(Genre genge)
        {
            if(genge is null || string.IsNullOrEmpty(genge.Name))
                return this;

            _request.AddParameter("genres", genge.Name);
            return this;
        }

        public IQueryBuilder AddPage(int page)
        {
            _request.AddParameter("page", page);
            return this;
        }

        public IQueryBuilder AddPageSize(int size)
        {
            _request.AddParameter("size", size);
            return this;
        }

        public IQueryBuilder AddSearch(string search)
        {
            if(string.IsNullOrEmpty(search))
                return this;

            _request.AddParameter("search", search);
            return this;
        }

        public IQueryBuilder AddSortBy(string propertyName)
        {
            if(string.IsNullOrEmpty(propertyName))
                return this;

            _request.AddParameter("sortBy", propertyName);
            return this;
        }

        public IQueryBuilder AddSortOrder(bool isAsc)
        {
            if(isAsc)
                _request.AddParameter("sortOrder", "asc");
            else
                _request.AddParameter("sortOrder", "desc");

            return this;
        }

        public async Task<Payload<Anime>> BuildAsync()
        {
            RestResponse<Payload<Anime>> response = await _client.ExecuteAsync<Payload<Anime>>(_request);
            if (!response.IsSuccessful)
                return new Payload<Anime>();

            var payload = response.Data;
            if (payload is null)
                return new Payload<Anime>();

            return payload;
        }

        public IQueryBuilder Clear()
        {
            _request = new RestRequest("anime", Method.Get);
            return this;
        }
    }
}
