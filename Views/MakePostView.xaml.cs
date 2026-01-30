using System.Windows.Controls;
using MiniYou_App.ViewModels;

namespace MiniYou_App.Views
{
    public partial class MakePostView : UserControl
    {
        public MakePostView()
        {
            InitializeComponent();
            DataContext = new MakePostViewModel();
        }
    }
}
