using AnimeDb.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AnimeDb.Client.ViewModels.Common
{
    public class PaginationViewModel : BaseNotifyPropertyChanged
    {
        private IEnumerable<int> _sizes = new int[4] { 10, 30, 50, 100 };
        public IEnumerable<int> Sizes
        {
            get { return _sizes; }
            set { _sizes = value; }
        }

        private int _page = 1;
        public int Page
        {
            get => _page;
            set => SetField(ref _page, value);
        }

        private int _size = 10;
        public int Size
        {
            get => _size;
            set => SetField(ref _size, value);
        }

        private int _totalPage = 1;
        public int TotalPage
        {
            get => _totalPage;
            set => SetField(ref _totalPage, value);
        }

        private int _totalData = 1;
        public int TotalData
        {
            get => _totalData;
            set => SetField(ref _totalData, value);
        }

        public PaginationViewModel()
        {
            _page = 1;
            _size = 10;
            _totalPage = 0;
            _totalData = 0;

            CalculatedProperties.Add(nameof(Label));
        }

        public PaginationViewModel(Meta meta)
        {
            _page = meta.Page;
            _size = meta.Size;
            _totalPage = meta.TotalPage;
            _totalData = meta.TotalData;

            CalculatedProperties.Add(nameof(Label));
        }

        public string Label
            => $"Pagina {_page} de {_totalPage}";

        public bool HasNextPage
            => _page < _totalPage;

        public bool HasLastPage
            => _page > 1;

    }
}
