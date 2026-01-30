using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MiniYou_App.ViewModels
{
    public class MakePostViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _titre = "";
        private string? _texte = "";
        private string _status = "Prêt.";

        public string Titre
        {
            get => _titre;
            set
            {
                if (_titre == value) return;
                _titre = value;
                OnPropertyChanged();
                Status = $"Titre modifié ({DateTime.Now:HH:mm:ss})";
                PublishCommand.RaiseCanExecuteChanged();
            }
        }

        public string? Texte
        {
            get => _texte;
            set
            {
                if (_texte == value) return;
                _texte = value;
                OnPropertyChanged();
                Status = $"Texte modifié ({DateTime.Now:HH:mm:ss})";
                PublishCommand.RaiseCanExecuteChanged();
            }
        }

        public string Status
        {
            get => _status;
            set
            {
                if (_status == value) return;
                _status = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand PublishCommand { get; }

        public MakePostViewModel()
        {
            PublishCommand = new RelayCommand(Publish, CanPublish);
        }

        private bool CanPublish()
            => !string.IsNullOrWhiteSpace(Titre) && !string.IsNullOrWhiteSpace(Texte);

        private void Publish()
        {
            // Ici plus tard tu créereras ton Post + appel API
            Status = "Publié ✅";
            Titre = "";
            Texte = "";
        }

        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
