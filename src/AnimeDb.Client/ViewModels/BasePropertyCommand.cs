using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnimeDb.Client.ViewModels
{
    public abstract class BaseCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public abstract bool CanExecute(object? parameter);

        public abstract void Execute(object? parameter);
    }

    public abstract class BasePropertyCommand<T> : BaseCommand
    {
        public override bool CanExecute(object? parameter)
        {
            if (parameter is T viewModel)
                return CanExecute(viewModel);

            return false;
        }

        protected abstract bool CanExecute(T viewModel);

        public override void Execute(object? parameter)
        {
            if (parameter is T viewModel)
                Execute(viewModel);
        }

        protected abstract void Execute(T viewModel);
    }
}
