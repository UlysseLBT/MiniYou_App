using Miniyou.Models;
using MiniYou_App.Command;
using MiniYou_App.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace MiniYou_App.ViewModels
{
    internal class PostListingViewModel : INotifyPropertyChanged
    {
        private readonly PostService _postService = new PostService();

        public ObservableCollection<Post> Posts { get; } = new ObservableCollection<Post>();

        public ICommand LoadCommand { get; }

        public PostListingViewModel()
        {
            LoadCommand = new RelayCommand(async _ => await LoadPosts());
            _ = LoadPosts(); // auto-load au démarrage
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private async Task LoadPosts()
        {
            try
            {
                var posts = await _postService.GetPosts();
                Posts.Clear();
                foreach (var post in posts)
                    Posts.Add(post);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading posts: {ex.Message}");
            }
        }
    }
}
