using System.Windows.Controls;
using MiniYou_App.ViewModels;

namespace MiniYou_App.Views
{
    public partial class PostListingView : UserControl
    {
        public PostListingView()
        {
            InitializeComponent();
            DataContext = new PostListingViewModel();
        }
    }
}
