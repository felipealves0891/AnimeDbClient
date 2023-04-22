using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnimeDb.Client.ViewModels
{
    public class BaseNotifyPropertyChanged : INotifyPropertyChanged
    {
        protected ICollection<BaseCommand> Commands { get; set; } = new List<BaseCommand>();
        protected ICollection<string> CalculatedProperties = new List<string>();

        protected void SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if(!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                OnPropertyChanged(propertyName ?? string.Empty);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            foreach (var command in Commands)
                command.OnCanExecuteChanged();

            foreach (var calculatedProperty in CalculatedProperties)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(calculatedProperty));
        }
    }
}
