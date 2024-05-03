using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Healink.Business.Entities;

namespace Healink.Entities
{
    public class Likes : ILikes
    {
        #region properties
        [Key]
        public long LikeId { get; set; }

        [Required]
        [ForeignKey("LikedPostId")]
        public long PostId { get; set; }

        [Required]
        [ForeignKey("LikedUserId")]
        public long UserId { get; set; }
        #endregion

        [InverseProperty("LikedUser")]
        public virtual User LikedUserId { get; set; }

        [InverseProperty("LikedPost")]
        public virtual Post LikedPostId { get; set; }
    }
}
