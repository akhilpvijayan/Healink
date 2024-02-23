using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Healink.Entities
{
    public class Message
    {
        #region properties
        [Key]
        public long MessageId { get; set; }

        [Required]
        [MaxLength(500)]
        public string MessageContent { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        public bool IsRead { get; set; } = false;

        [Required]
        [ForeignKey("Sender")]
        public long SenderId { get; set; }

        [Required]
        [ForeignKey("Receiver")]
        public long ReceiverId { get; set; }
        #endregion

        [InverseProperty("SentMessages")]
        public virtual User Sender { get; set; }

        [InverseProperty("ReceivedMessages")]
        public virtual User Receiver { get; set; }
    }
}
