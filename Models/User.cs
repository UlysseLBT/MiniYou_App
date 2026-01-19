namespace Miniyou.Models
{
    public class User
    {
        public long Id { get; set; }

        public string Name { get; set; } = "";

        public string? Username { get; set; }

        public string Email { get; set; } = "";

        public DateTime? EmailVerifiedAt { get; set; }

        public string Password { get; set; } = "";

        public string? DisplayName { get; set; }

        public string? AvatarPath { get; set; }

        public string? Bio { get; set; }

        public string? Website { get; set; }

        public string? Twitter { get; set; }

        public string? Instagram { get; set; }

        public string? RememberToken { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
