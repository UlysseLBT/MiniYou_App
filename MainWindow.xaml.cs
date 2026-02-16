using System.Windows;
using MiniYou_App.ViewModels;

namespace MiniYou_App
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new UserListingViewModel();
            InitializeComponent();
        }
    }
}
