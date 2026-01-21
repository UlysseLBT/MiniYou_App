namespace Miniyou.Models
{
    public class CommunityInvitation
    {
        public long Id { get; set; }
        public long CommunityId { get; set; }

        public long InviterId { get; set; }
        public long? InviteeId { get; set; }

        public string Token { get; set; }

        public string Status { get; set; }

        public DateTime? ExpiresAt { get; set; }
        public DateTime? AcceptedAt { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Community? Community { get; set; }
        public User? Inviter { get; set; }
        public User? Invitee { get; set; }

        public CommunityInvitation()
        {
            Token = string.Empty;
            Status = "pending";
        }

        public CommunityInvitation(
            long id,
            long communityId,
            long inviterId,
            long? inviteeId,
            string token,
            string status,
            DateTime? expiresAt,
            DateTime? acceptedAt,
            DateTime? createdAt,
            DateTime? updatedAt
        )
        {
            Id = id;
            CommunityId = communityId;
            InviterId = inviterId;
            InviteeId = inviteeId;
            Token = token;
            Status = status;
            ExpiresAt = expiresAt;
            AcceptedAt = acceptedAt;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}

