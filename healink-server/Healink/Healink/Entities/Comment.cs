using Healink.Business.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Healink.Entities
{
    public class Comment : BaseEntity, IComment
    {
        #region properties
        [Key]
        public long CommentId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Content { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }

        [Required]
        [ForeignKey("Post")]
        public long PostId { get; set; }

        [Required]
        [ForeignKey("User")]
        public long UserId { get; set; }
        #endregion

        public virtual Post Post { get; set; }

        [InverseProperty("UserComment")]
        public virtual User User { get; set; }

    }
}
