using Healink.Business.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Healink.Entities
{
    public class Connection : IConnection
    {
        #region properties
        [Key]
        public long ConnectionId { get; set; }

        [Required]
        public DateTime RequestedDate { get; set; }

        public DateTime AcceptedDate { get; set; }

        [Required]
        [ForeignKey("Sender")]
        public long SenderId { get; set; }

        [Required]
        [ForeignKey("Receiver")]
        public long ReceiverId { get; set; }

        [Required]
        public string Status { get; set; }
        #endregion

        [InverseProperty("SentUser")]
        public virtual User Sender { get; set; }

        [InverseProperty("ReceivedUser")]
        public virtual User Receiver { get; set; }

    }
}
