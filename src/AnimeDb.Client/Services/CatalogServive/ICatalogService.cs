using AnimeDb.Client.ViewModels.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeDb.Client.Services.CatalogServive
{
    public interface ICatalogService
    {
        Task UpdateAsync(CatalogViewModel viewModel);
    }
}
