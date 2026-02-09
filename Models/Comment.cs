namespace Miniyou.Models
{
    public class Comment
    {

        public long Id { get; }
        public long PostId { get; }
        public long UserId { get; }
        public string Body { get; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Post? Post { get; }
        public User? User { get; }
        public Comment()
        {
            Body = string.Empty;
        }
        public Comment(
            long id,
            long postId,
            long userId,
            string body,
            DateTime? createdAt,
            DateTime? updatedAt
        )
        {
            Id = id;
            PostId = postId;
            UserId = userId;
            Body = body;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
