using AnimeDb.Client.Services.CatalogServive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeDb.Client.ViewModels.Catalog
{
    public class SearchCommand : BasePropertyCommand<CatalogViewModel>
    {
        private readonly ICatalogService _service;

        public SearchCommand(ICatalogService service)
        {
            _service = service;
        }

        protected override bool CanExecute(CatalogViewModel viewModel)
        {
            return !string.IsNullOrEmpty(viewModel.Searched) || viewModel.SelectedGenre is not null;
        }

        protected async override void Execute(CatalogViewModel viewModel)
        {
            await _service.UpdateAsync(viewModel);
        }
    }
}
