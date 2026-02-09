namespace Miniyou.Models
{
    public class CommunityJoinRequest
    {
        public long Id { get; }

        public long CommunityId { get; }
        public long UserId { get; }

        public string Status { get; set; }

        public string? Message { get; set; }

        public long? HandledBy { get; set; }
        public DateTime? HandledAt { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Community? Community { get; set; }
        public User? User { get; set; }
        public User? Handler { get; set; }

        public CommunityJoinRequest()
        {
            Status = "pending";
        }

        public CommunityJoinRequest(
            long id,
            long communityId,
            long userId,
            string status,
            string? message,
            long? handledBy,
            DateTime? handledAt,
            DateTime? createdAt,
            DateTime? updatedAt
        )
        {
            Id = id;
            CommunityId = communityId;
            UserId = userId;
            Status = status;
            Message = message;
            HandledBy = handledBy;
            HandledAt = handledAt;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
