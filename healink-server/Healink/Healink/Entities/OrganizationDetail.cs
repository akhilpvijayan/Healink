using Healink.Business.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Healink.Entities
{
    public class OrganizationDetail : BaseEntity, IOrganizationDetail
    {
        #region properties
        [Key]
        public long OrganizationDetailId { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string OrganizationName { get; set; }

        [Required]
        [MaxLength(100)]
        public string OrganizationWebsite { get; set; }

        [Required]
        public long OrganizationSize { get; set; }

        [Required]
        public string OrganizationLogo { get; set; }

        [Required]
        [MaxLength(500)]
        public string OrganizationBio { get; set; }

        [Required]
        [ForeignKey("UserCountry")]
        public long CountryId { get; set; }

        [Required]
        [ForeignKey("UserState")]
        public long StateId { get; set; }

        public string Region { get; set; }

        [Required]
        [ForeignKey("IndustryType")]
        public long OrganizationTypeId { get; set; }

        [Required]
        public int FollowCount { get; set; }

        [Required]
        [MaxLength(100)]
        public string TagLine { get; set; }

        #endregion
        public virtual User User { get; set; }
        public virtual IndustryType IndustryType { get; set; }
        public virtual Country UserCountry { get; set; }
        [ForeignKey("StateId")]
        public virtual State UserState { get; set; }
    }
}
