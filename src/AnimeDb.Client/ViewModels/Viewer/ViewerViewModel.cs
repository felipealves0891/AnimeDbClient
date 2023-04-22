using AnimeDb.Client.Configurations.Attributes;
using AnimeDb.Client.Models;
using AnimeDb.Client.Services.AnimeRepositories;
using AnimeDb.Client.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeDb.Client.ViewModels.Viewer
{
    public class ViewerViewModel : BaseNotifyPropertyChanged
    {
        private readonly IAnimeRepository _animeRepository;

        private Anime _anime;
        public Anime Anime
        {
            get => _anime;
            set => SetField(ref _anime, value);
        }

        public ViewerViewModel(IAnimeRepository repository)
        {
            _animeRepository = repository;
            _anime = new Anime();
        }

        public WindowViewModel Window { get; set; } = new WindowViewModel();

        [InjectParameter("Id")]
        public async void LoadAnime(string id)
        {
            Window.Loading = true;
            Anime = await _animeRepository.GetById(id);
            Window.Loading = false;
        }
    }
}
