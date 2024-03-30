using Healink.Business.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Healink.Entities
{
    public class UserDetail :BaseEntity, IUserDetail
    {
        #region properties
        [Key]
        public long UserDetailId { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength]
        public string LastName { get; set; }

        public byte[]? ProfileImage { get; set; } = null;

        public byte[]? ProfileCover { get; set; } = null;

        [Required]
        [MaxLength(100)]
        public string UserBio { get; set; }


        [Required]
        public string Gender { get; set; }

        [Required]
        [ForeignKey("UserCountry")]
        public long CountryId { get; set; }

        [Required]
        [ForeignKey("UserState")]
        public long StateId { get; set; }

        public string Region { get; set; }

        [Required]
        [MaxLength(50)]
        public string Specialization { get; set; }

        public int? ConnectionsCount { get; set; } = 0;
        #endregion
        public virtual User User { get; set; }

        public virtual Country UserCountry { get; set; }

        [InverseProperty("UState")]
        public virtual State UserState { get; set; }
    }
}
