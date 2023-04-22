using AnimeDb.Client.Models;
using AnimeDb.Client.Services.AnimeRepositories;
using AnimeDb.Client.Services.QueryBuilderService;
using AnimeDb.Client.ViewModels.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeDb.Client.Services.CatalogServive
{
    public class Catalog : ICatalogService
    {
        private readonly IAnimeRepository _repository;
        private readonly IQueryBuilder _queryBuilder;

        public Catalog(IAnimeRepository repository, IQueryBuilder queryBuilder)
        {
            _repository = repository;
            _queryBuilder = queryBuilder;
        }

        public async Task UpdateAsync(CatalogViewModel viewModel)
        {
            viewModel.Window.Loading = true;
            await PaginationAsync(viewModel);
            viewModel.Window.Loading = false;
        }

        private async Task PaginationAsync(CatalogViewModel viewModel)
        {
            var payload = await _queryBuilder.Clear()
                                       .AddPage(viewModel.Pagination.Page)
                                       .AddPageSize(viewModel.Pagination.Size)
                                       .AddSearch(viewModel.Searched)
                                       .AddGenre(viewModel.SelectedGenre)
                                       .BuildAsync();

            UpdateStatus(viewModel, payload);
        }

        private void UpdateStatus(CatalogViewModel viewModel, Payload<Anime> payload)
        {
            var meta = payload.Meta ?? new Meta();
            viewModel.Pagination.Size = meta.Size;
            viewModel.Pagination.Page = meta.Page;
            viewModel.Pagination.TotalPage = meta.TotalPage;
            viewModel.Pagination.TotalData = meta.TotalData;
            viewModel.Animes = payload.Data;
        }

    }
}
