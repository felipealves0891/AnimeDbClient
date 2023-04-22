using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeDb.Client.ViewModels.Common
{
    public class WindowViewModel : BaseNotifyPropertyChanged
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }

        private bool _displayingFilter;
        public bool DisplayingFilter
        {
            get => _displayingFilter;
            set => SetField(ref _displayingFilter, value);
        }

        private bool _loading;
        public bool Loading
        {
            get => _loading;
            set => SetField(ref _loading, value);
        }

        public WindowViewModel()
        {
            CalculatedProperties.Add("IsReady");

            _title = "Anime DB";
            _displayingFilter = false;
            _loading = true;
        }

        public bool IsReady => !_loading;
    }
}
