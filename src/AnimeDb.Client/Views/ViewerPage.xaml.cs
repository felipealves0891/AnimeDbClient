using AnimeDb.Client.Configurations.Attributes;
using AnimeDb.Client.ViewModels.Viewer;
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

namespace AnimeDb.Client.Views
{
    /// <summary>
    /// Interaction logic for ViewerPage.xaml
    /// </summary>
    [DataContextUse(typeof(ViewerViewModel))]
    public partial class ViewerPage : Page
    {
        public ViewerPage()
        {
            InitializeComponent();
        }
    }
}
