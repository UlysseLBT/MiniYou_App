using System.Text.Json.Serialization;

namespace Miniyou.Models
{
    public class User
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("username")]
        public string? Username { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("email_verified_at")]
        public DateTime? EmailVerifiedAt { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
        [JsonPropertyName("display_name")]
        public string? DisplayName { get; set; }
        [JsonPropertyName("avatar_path")]
        public string? AvatarPath { get; set; }
        [JsonPropertyName("bio")]
        public string? Bio { get; set; }
        [JsonPropertyName("website")]
        public string? Website { get; set; }
        [JsonPropertyName("twitter")]
        public string? Twitter { get; set; }
        [JsonPropertyName("instagram")]
        public string? Instagram { get; set; }
        [JsonPropertyName("remember_token")]
        public string? RememberToken { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public User()
        {
            Name = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
        }


        public User(
            int id,
            string name,
            string? username,
            string email,
            DateTime? emailVerifiedAt,
            string password,
            string? displayName,
            string? avatarPath,
            string? bio,
            string? website,
            string? twitter,
            string? instagram,
            string? rememberToken,
            DateTime? createdAt,
            DateTime? updatedAt
        )
        {
            Id = (int)id;
            Name = name;
            Username = username;
            Email = email;
            EmailVerifiedAt = emailVerifiedAt;
            Password = password;
            DisplayName = displayName;
            AvatarPath = avatarPath;
            Bio = bio;
            Website = website;
            Twitter = twitter;
            Instagram = instagram;
            RememberToken = rememberToken;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
