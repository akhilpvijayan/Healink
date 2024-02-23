using Healink.Business.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Healink.Entities
{
    public class Post : BaseEntity, IPost
    {
        #region properties
        [Key]
        public long PostId { get; set; }

        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        [Required]
        public string ContentImage { get; set; }

        public long LikeCount { get; set; } = 0;

        [Required]
        [ForeignKey("User")]
        public long UserId { get; set; }
        #endregion

        public virtual User User { get; set; }
    }
}
