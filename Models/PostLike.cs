namespace Miniyou.Models
{
    public class PostLike
    {
        public long Id { get; }
        public long PostId { get; }
        public long UserId { get; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Post? Post { get; set; }
        public User? User { get; set; }

        public PostLike()
        {
        }
        public PostLike(
            long id,
            long postId,
            long userId,
            DateTime? createdAt,
            DateTime? updatedAt
        )
        {
            Id = id;
            PostId = postId;
            UserId = userId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
