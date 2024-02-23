using Healink.Business.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Healink.Entities
{
    public class Job : BaseEntity, IJob
    {
        #region properties
        [Key]
        public long JobId { get; set; }

        [Required]
        [MaxLength(100)]
        public string JobTitle { get; set; }

        [Required]
        [MaxLength(500)]
        public string JobDescription { get; set; }

        [Required]
        public string JobUrl { get; set; }

        [Required]
        public string Location { get; set; }

        public string Salary { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        [Required]
        [ForeignKey("User")]
        public long UserId { get; set; }

        [Required]
        [ForeignKey("Organization")]
        public long OrganizationDetailId { get; set; }
        #endregion

        [InverseProperty("UserJob")]
        public virtual User User { get; set; }

        public virtual OrganizationDetail Organization { get; set; }
    }
}
