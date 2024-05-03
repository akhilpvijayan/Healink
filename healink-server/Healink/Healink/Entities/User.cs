using Healink.Business.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Healink.Entities
{
    public class User: IUser
    {
        #region properties
        [Key]
        public long UserId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime LastLogin { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required]
        public bool IsActive { get; set; } = true;
        public bool IsVerified { get; set; } = false;
        [ForeignKey("Role")]
        public long RoleId { get; set; }
        public string? RefreshToken { get; set; } = null;
        public DateTime RefreshTokenExpiry { get; set; }
        #endregion

        public virtual Role Role { get; set; }

        [InverseProperty("Sender")]
        public virtual ICollection<Message> SentMessages { get; set; }

        [InverseProperty("Receiver")]
        public virtual ICollection<Message> ReceivedMessages { get; set; }

        [InverseProperty("Sender")]
        public virtual ICollection<Connection> SentUser { get; set; }

        [InverseProperty("Receiver")]
        public virtual ICollection<Connection> ReceivedUser { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Comment> UserComment { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Job> UserJob { get; set; }

        [InverseProperty("SendUser")]
        public virtual ICollection<Chats> UserSend { get; set; }

        [InverseProperty("ReceivedUser")]
        public virtual ICollection<Chats> UserReceived { get; set; }

        [InverseProperty("LikedUserId")]
        public virtual ICollection<Likes> LikedUser { get; set; }
    }
}
