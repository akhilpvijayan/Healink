using Healink.Business.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Healink.Entities
{
    public class Experience : BaseEntity, IExperience
    {
        #region properties
        [Key]
        public long ExperienceId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Company { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        [ForeignKey("User")]
        public long UserId { get; set; }
        #endregion

        public virtual User User { get; set; }
    }
}
