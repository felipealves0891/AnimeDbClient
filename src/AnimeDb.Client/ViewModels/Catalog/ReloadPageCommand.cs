using AnimeDb.Client.Services.CatalogServive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeDb.Client.ViewModels.Catalog
{
    public class ReloadPageCommand : BasePropertyCommand<CatalogViewModel>
    {
        private readonly ICatalogService _catalogService;

        public ReloadPageCommand(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        protected override bool CanExecute(CatalogViewModel viewModel)
        {
            return true;
        }

        protected override async void Execute(CatalogViewModel viewModel)
        {
            await _catalogService.UpdateAsync(viewModel);
        }
    }
}
