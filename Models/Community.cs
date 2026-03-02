using System;
using System.Text.Json.Serialization;

namespace Miniyou.Models
{
    public class Community
    {
        [JsonPropertyName("id")]
        public int Id { get; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("slug")]
        public string Slug { get; set; }
        [JsonPropertyName("description")]
        public string? Description { get; set; }
        [JsonPropertyName("is_private")]
        public bool IsPrivate { get; set; }
        [JsonPropertyName("visibility")]
        public string Visibility { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public User? Owner { get; set; }

        public Community()
        {
            Name = string.Empty;
            Slug = string.Empty;
            Visibility = "public";
            IsPrivate = false;
        }

        public Community(
            int id,
            string name,
            string slug,
            string? description,
            bool isPrivate,
            string visibility,
            DateTime? createdAt,
            DateTime? updatedAt
        )
        {
            Id = (int)id;
            Name = name;
            Slug = slug;
            Description = description;
            IsPrivate = isPrivate;
            Visibility = visibility;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
