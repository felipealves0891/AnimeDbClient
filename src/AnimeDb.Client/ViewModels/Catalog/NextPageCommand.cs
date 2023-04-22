using AnimeDb.Client.Services.AnimeRepositories;
using AnimeDb.Client.Services.CatalogServive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeDb.Client.ViewModels.Catalog
{
    public class NextPageCommand : BasePropertyCommand<CatalogViewModel>
    {
        private readonly ICatalogService _service;

        public NextPageCommand(ICatalogService service)
        {
            _service = service;
        }

        protected override bool CanExecute(CatalogViewModel viewModel)
        {
            var pagination = viewModel.Pagination;
            return pagination.HasNextPage;
        }

        protected async override void Execute(CatalogViewModel viewModel)
        {
            viewModel.Pagination.Page = viewModel.Pagination.Page + 1;
            await _service.UpdateAsync(viewModel);
        }
    }
}
