using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Miniyou.ViewModels
{
    public class UserItem : INotifyPropertyChanged
    {
        private long _id;
        private string _name = "";
        private string? _username;
        private string _email = "";
        private string? _displayName;
        private string? _avatarPath;
        private string? _bio;
        private string? _website;
        private string? _twitter;
        private string? _instagram;

        public long Id { get => _id; set { if (_id != value) { _id = value; OnPropertyChanged(); } } }

        public string Name { get => _name; set { if (_name != value) { _name = value; OnPropertyChanged(); } } }

        public string? Username { get => _username; set { if (_username != value) { _username = value; OnPropertyChanged(); } } }

        public string Email { get => _email; set { if (_email != value) { _email = value; OnPropertyChanged(); } } }

        public string? DisplayName { get => _displayName; set { if (_displayName != value) { _displayName = value; OnPropertyChanged(); } } }

        public string? AvatarPath { get => _avatarPath; set { if (_avatarPath != value) { _avatarPath = value; OnPropertyChanged(); } } }

        public string? Bio { get => _bio; set { if (_bio != value) { _bio = value; OnPropertyChanged(); } } }

        public string? Website { get => _website; set { if (_website != value) { _website = value; OnPropertyChanged(); } } }

        public string? Twitter { get => _twitter; set { if (_twitter != value) { _twitter = value; OnPropertyChanged(); } } }

        public string? Instagram { get => _instagram; set { if (_instagram != value) { _instagram = value; OnPropertyChanged(); } } }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
