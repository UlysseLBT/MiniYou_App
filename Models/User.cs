namespace Miniyou.Models
{
    public class User
    {
        public long Id { get; }
        public string Name { get; }
        public string? Username { get; set; }
        public string Email { get; set; }
        public DateTime? EmailVerifiedAt { get; set; }
        public string Password { get; set; }
        public string? DisplayName { get; set; }
        public string? AvatarPath { get; set; }
        public string? Bio { get; set; }
        public string? Website { get; set; }
        public string? Twitter { get; set; }
        public string? Instagram { get; set; }
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
            long id,
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
            Id = id;
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
