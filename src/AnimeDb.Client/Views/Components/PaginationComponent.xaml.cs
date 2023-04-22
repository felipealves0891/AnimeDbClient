using AnimeDb.Client.ViewModels.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimeDb.Client.Views.Components
{
    /// <summary>
    /// Interaction logic for PaginationComponent.xaml
    /// </summary>
    public partial class PaginationComponent : UserControl
    {
        public PaginationComponent()
        {
            InitializeComponent();
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            cbSizes.SelectionChanged += ComboBox_SelectionChanged;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var context = (CatalogViewModel)this.DataContext;
            if (context.ReloadPageCommand.CanExecute(context))
                context.ReloadPageCommand.Execute(context);
        }

    }
}
