namespace Miniyou.Models
{
    public class CommunityUser
    {
        public long Id { get; }
        public long CommunityId { get; }
        public long UserId { get; }
        public string Role { get; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Community? Community { get; set; }
        public User? User { get; set; }
        public CommunityUser()
        {
            Role = "member";
        }

        public CommunityUser(
            long id,
            long communityId,
            long userId,
            string role,
            DateTime? createdAt,
            DateTime? updatedAt
        )
        {
            Id = id;
            CommunityId = communityId;
            UserId = userId;
            Role = role;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
