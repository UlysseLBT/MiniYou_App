using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MiniYou_App.ViewModels
{
    public class MakePostViewModel : INotifyPropertyChanged
    {
        private string _titre = "";
        private string _texte = "";
        private string _status = "Prêt";

        public string Titre
        {
            get => _titre;
            set
            {
                if (_titre != value)
                {
                    _titre = value;
                    OnPropertyChanged();
                    CommandManager.InvalidateRequerySuggested();
                }
            }
        }

        public string Texte
        {
            get => _texte;
            set
            {
                if (_texte != value)
                {
                    _texte = value;
                    OnPropertyChanged();
                    CommandManager.InvalidateRequerySuggested();
                }
            }
        }

        public string Status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand PublishCommand { get; }

        public MakePostViewModel()
        {
            PublishCommand = new RelayCommand(async () => await PublishAsync(), CanPublish);
        }

        private bool CanPublish()
        {
            return !string.IsNullOrWhiteSpace(Titre)
                && !string.IsNullOrWhiteSpace(Texte);
        }

        private async Task PublishAsync()
        {
            Status = "Publication...";
            await Task.Delay(250); // ici tu brancheras ton API plus tard

            Status = "Publié !";
            Titre = "";
            Texte = "";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
