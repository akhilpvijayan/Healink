using Healink.Business.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Healink.Entities
{
    public class Education: BaseEntity, IEducation
    {
        #region properties
        [Key]
        public long EducationId { get; set; }

        [Required]
        public string Institution { get; set; }

        [Required]
        public string Degree { get; set; }

        [Required]
        public string FieldOfStudy { get; set; }

        [Required]
        public DateTime GraduationstartDate { get; set; }

        public DateTime? GraduationEndDate { get; set; } = null;

        public string? GraduationDescription { get; set; } = null;

        public long? OrgId { get; set; } = null;

        [Required]
        [ForeignKey("User")]
        public long UserId { get; set; }
        #endregion
        public virtual User User { get; set; }
        [InverseProperty("OrgDetails")]
        public virtual OrganizationDetail OrganizationDetails { get; set; }

    }
}
