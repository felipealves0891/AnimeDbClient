using AnimeDb.Client.Services.AnimeRepositories;
using AnimeDb.Client.Services.CatalogServive;

namespace AnimeDb.Client.ViewModels.Catalog
{
    public class LoaderCommand : BasePropertyCommand<CatalogViewModel>
    {
        private readonly ICatalogService _service;
        private readonly IAnimeRepository _repository;

        public LoaderCommand(ICatalogService service, IAnimeRepository repository)
        {
            _service = service;
            _repository = repository;
        }

        protected override bool CanExecute(CatalogViewModel viewModel)
        {
            return true;
        }

        protected async override void Execute(CatalogViewModel viewModel)
        {
            viewModel.Genres = await _repository.GetGenresAsync();
            await _service.UpdateAsync(viewModel);
        }
    }
}
