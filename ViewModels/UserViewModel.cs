using MiniYou_App.Command;
using MiniYou_App.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Windows.Input;

namespace Miniyou.ViewModels
{
    public class UserViewModel
    {
        private readonly HttpClient _http;
        private readonly JsonSerializerOptions _json = new() { PropertyNameCaseInsensitive = true };

        private const string ENDPOINT = "api/users"; // change si c'est /api/user

        public ObservableCollection<UserItem> Users { get; } = new();

        private UserItem? _selectedUser;
        public UserItem? SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                CommandManager.InvalidateRequerySuggested();
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            private set
            {
                _isBusy = value;
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public string? Error { get; private set; }

        public ICommand LoadCommand { get; }
        public ICommand NewCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand ClearSelectionCommand { get; }

        public UserViewModel() : this("http://127.0.0.1:8000") { }

        public UserViewModel(string apiBaseUrl)
        {
            _http = new HttpClient
            {
                BaseAddress = new Uri(apiBaseUrl.TrimEnd('/') + "/")
            };

            LoadCommand = new RelayCommand(_ => Load(), _ => !IsBusy);
            NewCommand = new RelayCommand(_ => NewUser(), _ => !IsBusy);
            SaveCommand = new RelayCommand(_ => Save(), _ => !IsBusy && SelectedUser != null);
            DeleteCommand = new RelayCommand(_ => Delete(), _ => !IsBusy && SelectedUser != null);
            ClearSelectionCommand = new RelayCommand(_ => SelectedUser = null, _ => !IsBusy);

        }

        public void SetBearerToken(string token)
        {
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        private async void Load() => await LoadAsync();
        private async void Save() => await SaveAsync();
        private async void Delete() => await DeleteAsync();

        private void NewUser()
        {
            Error = null;

            var u = new UserItem
            {
                Id = 0,
                Name = "Nouveau",
                Email = "",
                Username = null,
                DisplayName = null,
                AvatarPath = null,
                Bio = null,
                Website = null,
                Twitter = null,
                Instagram = null
            };

            Users.Add(u);
            SelectedUser = u;
        }

        private async System.Threading.Tasks.Task LoadAsync()
        {
            Error = null;
            IsBusy = true;

            try
            {
                Users.Clear();

                var jsonText = await _http.GetStringAsync(ENDPOINT);

                // ✅ Robust : supporte JSON camelCase OU snake_case (selon ton backend)
                using var doc = JsonDocument.Parse(jsonText);

                if (doc.RootElement.ValueKind == JsonValueKind.Array)
                {
                    foreach (var e in doc.RootElement.EnumerateArray())
                    {
                        Users.Add(new UserItem
                        {
                            Id = GetLong(e, "id", "Id"),
                            Name = GetString(e, "name", "Name") ?? "",
                            Username = GetString(e, "username", "Username"),
                            Email = GetString(e, "email", "Email") ?? "",
                            DisplayName = GetString(e, "display_name", "displayName", "DisplayName"),
                            AvatarPath = GetString(e, "avatar_path", "avatarPath", "AvatarPath"),
                            Bio = GetString(e, "bio", "Bio"),
                            Website = GetString(e, "website", "Website"),
                            Twitter = GetString(e, "twitter", "Twitter"),
                            Instagram = GetString(e, "instagram", "Instagram"),
                        });
                    }
                }

                SelectedUser = Users.Count > 0 ? Users[0] : null;
            }
            catch (Exception ex)
            {
                Error = "Load: " + ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async System.Threading.Tasks.Task SaveAsync()
        {
            if (SelectedUser == null) return;

            Error = null;
            IsBusy = true;

            try
            {
                // ⚠️ On n'envoie PAS Password / RememberToken ici (sécurité)
                var body = new
                {
                    name = SelectedUser.Name,
                    username = SelectedUser.Username,
                    email = SelectedUser.Email,
                    display_name = SelectedUser.DisplayName,
                    avatar_path = SelectedUser.AvatarPath,
                    bio = SelectedUser.Bio,
                    website = SelectedUser.Website,
                    twitter = SelectedUser.Twitter,
                    instagram = SelectedUser.Instagram
                };

                HttpResponseMessage resp;

                if (SelectedUser.Id == 0)
                {
                    resp = await SendJsonAsync(HttpMethod.Post, ENDPOINT, body);
                }
                else
                {
                    resp = await SendJsonAsync(HttpMethod.Put, $"{ENDPOINT}/{SelectedUser.Id}", body);
                }

                resp.EnsureSuccessStatusCode();

                // recharge pour récupérer l'id / synchro
                await LoadAsync();
            }
            catch (Exception ex)
            {
                Error = "Save: " + ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async System.Threading.Tasks.Task DeleteAsync()
        {
            if (SelectedUser == null) return;

            Error = null;
            IsBusy = true;

            try
            {
                if (SelectedUser.Id == 0)
                {
                    Users.Remove(SelectedUser);
                    SelectedUser = null;
                    return;
                }

                var resp = await _http.DeleteAsync($"{ENDPOINT}/{SelectedUser.Id}");
                resp.EnsureSuccessStatusCode();

                Users.Remove(SelectedUser);
                SelectedUser = Users.Count > 0 ? Users[0] : null;
            }
            catch (Exception ex)
            {
                Error = "Delete: " + ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async System.Threading.Tasks.Task<HttpResponseMessage> SendJsonAsync(HttpMethod method, string url, object body)
        {
            var jsonBody = JsonSerializer.Serialize(body, _json);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            var req = new HttpRequestMessage(method, url) { Content = content };
            return await _http.SendAsync(req);
        }

        // Helpers JSON (robuste)
        private static string? GetString(JsonElement e, params string[] names)
        {
            foreach (var n in names)
            {
                if (e.TryGetProperty(n, out var p) && p.ValueKind != JsonValueKind.Null)
                    return p.GetString();
            }
            return null;
        }

        private static long GetLong(JsonElement e, params string[] names)
        {
            foreach (var n in names)
            {
                if (e.TryGetProperty(n, out var p))
                {
                    if (p.ValueKind == JsonValueKind.Number && p.TryGetInt64(out var v)) return v;
                    if (p.ValueKind == JsonValueKind.String && long.TryParse(p.GetString(), out var s)) return s;
                }
            }
            return 0;
        }
    }
}
