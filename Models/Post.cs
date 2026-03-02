using System.Text.Json.Serialization;

namespace Miniyou.Models
{
    public class Post
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("titre")]
        public string Titre { get; set; }
        [JsonPropertyName("texte")]
        public string? Texte { get; set; }
        [JsonPropertyName("url")]
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
            int id,
            string titre,
            string? texte,
            string? url,
            DateTime? createdAt,
            DateTime? updatedAt
        )
        {
            Id = (int)id;
            Titre = titre;
            Texte = texte;
            Url = url;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
