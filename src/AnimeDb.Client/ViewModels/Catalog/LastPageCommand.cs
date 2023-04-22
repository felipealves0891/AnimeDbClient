using AnimeDb.Client.Services.AnimeRepositories;
using AnimeDb.Client.Services.CatalogServive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeDb.Client.ViewModels.Catalog
{
    public class LastPageCommand : BasePropertyCommand<CatalogViewModel>
    {
        private readonly ICatalogService _service;

        public LastPageCommand(ICatalogService service)
        {
            _service = service;
        }

        protected override bool CanExecute(CatalogViewModel viewModel)
        {
            var pagination = viewModel.Pagination;
            return pagination.HasLastPage;
        }

        protected async override void Execute(CatalogViewModel viewModel)
        {
            viewModel.Pagination.Page = viewModel.Pagination.Page - 1;
            await _service.UpdateAsync(viewModel);
        }
    }
}
