namespace Miniyou.Models
{
    public class Post
    {
        public long Id { get; }
        public long UserId { get; }
        public long? CommunityId { get; }
        public string Titre { get; set; }
        public string? Texte { get; set; }
        public string? Url { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }


        public User? User { get; set; }
        public Community? Community { get; set; }


        public Post()
        {
            Titre = string.Empty;
        }

        public Post(
            long id,
            long userId,
            long? communityId,
            string titre,
            string? texte,
            string? url,
            DateTime? createdAt,
            DateTime? updatedAt
        )
        {
            Id = id;
            UserId = userId;
            CommunityId = communityId;
            Titre = titre;
            Texte = texte;
            Url = url;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
