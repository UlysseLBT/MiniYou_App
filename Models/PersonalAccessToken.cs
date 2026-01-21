namespace Miniyou.Models
{
    public class PersonalAccessToken
    {
        public long Id { get; set; }
        public string TokenableType { get; set; }
        public long TokenableId { get; set; }

        public string Name { get; set; }
        public string Token { get; set; }
        public string? Abilities { get; set; }

        public DateTime? LastUsedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public PersonalAccessToken()
        {
            TokenableType = string.Empty;
            Name = string.Empty;
            Token = string.Empty;
        }
        public PersonalAccessToken(
            long id,
            string tokenableType,
            long tokenableId,
            string name,
            string token,
            string? abilities,
            DateTime? lastUsedAt,
            DateTime? expiresAt,
            DateTime? createdAt,
            DateTime? updatedAt
        )
        {
            Id = id;
            TokenableType = tokenableType;
            TokenableId = tokenableId;
            Name = name;
            Token = token;
            Abilities = abilities;
            LastUsedAt = lastUsedAt;
            ExpiresAt = expiresAt;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
