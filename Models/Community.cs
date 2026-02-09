using System;

namespace Miniyou.Models
{
    public class Community
    {
        public long Id { get; }
        public long OwnerId { get; }

        public string Name { get; set; }
        public string Slug { get; set; }
        public string? Description { get; set; }

        public bool IsPrivate { get; set; }

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
            long id,
            long ownerId,
            string name,
            string slug,
            string? description,
            bool isPrivate,
            string visibility,
            DateTime? createdAt,
            DateTime? updatedAt
        )
        {
            Id = id;
            OwnerId = ownerId;
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
