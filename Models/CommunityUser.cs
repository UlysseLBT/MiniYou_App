namespace Miniyou.Models
{
    public class CommunityUser
    {
        public long Id { get; set; }
        public long CommunityId { get; set; }
        public long UserId { get; set; }
        public string Role { get; set; }
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
