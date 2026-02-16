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
    internal class UserListingViewModel : INotifyPropertyChanged
    {
        private readonly UserService _usersService = new UserService();

        public ObservableCollection<User> Users { get; } = new ObservableCollection<User>();

        private User? _selectedUser;
        public User? SelectedUser
        {
            get => _selectedUser;
            set
            {
                if (_selectedUser != value)
                {
                    _selectedUser = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand LoadCommand { get; }
        public ICommand AddCommand { get; } // si tu en as besoin

        public UserListingViewModel()
        {
            LoadCommand = new RelayCommand(async _ => await LoadUsers());

            // Si tu n'as pas encore "Add", mets une commande vide ou supprime AddCommand
            AddCommand = new RelayCommand(_ =>
            {
                MessageBox.Show("Add user: pas encore implémenté.");
            });

            _ = LoadUsers(); // auto-load au démarrage
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private async Task LoadUsers()
        {
            try
            {
                var users = await _usersService.GetUser();
                Users.Clear();
                foreach (var user in users)
                    Users.Add(user);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}");
            }
        }
    }
}
