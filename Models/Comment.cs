namespace Miniyou.Models
{
    public class Comment
    {

        public long Id { get; set; }
        public long PostId { get; set; }
        public long UserId { get; set; }
        public string Body { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Post? Post { get; set; }
        public User? User { get; set; }
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
