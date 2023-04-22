using AnimeDb.Client.Models;
using AnimeDb.Client.Services.AnimeRepositories;
using AnimeDb.Client.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnimeDb.Client.ViewModels.Catalog
{
    public class CatalogViewModel : BaseNotifyPropertyChanged
    {
        private Genre _selectedGenre;
        public Genre SelectedGenre
        {
            get => _selectedGenre;
            set => SetField(ref _selectedGenre, value);
        }

        private IEnumerable<Genre> _genres;
		public IEnumerable<Genre> Genres
		{
			get => _genres;
			set => SetField(ref _genres, value);
		}

        private IEnumerable<Anime> _animes;
        public IEnumerable<Anime> Animes
        {
            get => _animes;
            set => SetField(ref _animes, value);
        }

        private string _searched;
        public string Searched
        {
            get => _searched;
            set => SetField(ref _searched, value);
        }

        public CatalogViewModel(
            LoaderCommand loader, 
            LastPageCommand lastPage, 
            NextPageCommand nextPage, 
            ReloadPageCommand reloadPage,
            SearchCommand search)
        {
			_genres = new List<Genre>();
			_animes = new List<Anime>();
            _searched = string.Empty;

            LoaderCommand = loader;
            LastPageCommand = lastPage;
            NextPageCommand = nextPage;
            ReloadPageCommand = reloadPage;
            SearchCommand = search;

            Commands.Add(loader);
            Commands.Add(lastPage);
            Commands.Add(nextPage);
            Commands.Add(reloadPage);
            Commands.Add(search);
        }

        public WindowViewModel Window { get; set; } = new WindowViewModel();

        public PaginationViewModel Pagination { get; set; } = new PaginationViewModel();

        public ICommand LoaderCommand { get; set; }

        public ICommand NextPageCommand { get; set; }

        public ICommand LastPageCommand { get; set; }

        public ICommand ReloadPageCommand { get; set; }

        public ICommand SearchCommand { get; set; }

    }
}
