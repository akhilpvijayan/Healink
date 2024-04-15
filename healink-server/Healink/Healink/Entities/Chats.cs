using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Healink.Business.Entities;

namespace Healink.Entities
{
    public class Chats : BaseEntity, IChats
    {
        #region properties
        [Key]
        public long ChatId { get; set; }

        [Required]
        [ForeignKey("SendUser")]
        public long SendUserId { get; set; }

        [Required]
        [ForeignKey("ReceivedUser")]
        public long ReceivedUserId { get; set; }
        #endregion

        [InverseProperty("UserSend")]
        public virtual User SendUser { get; set; }

        [InverseProperty("UserReceived")]
        public virtual User ReceivedUser { get; set; }

        [InverseProperty("Chat")]
        public virtual ICollection<Message> UserChatId { get; set; }
    }
}
