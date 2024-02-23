using Healink.Business.Entities;
using System.ComponentModel.DataAnnotations;

namespace Healink.Entities
{
    public class Skill : BaseEntity,ISkill
    {
        #region properties
        [Key]
        public long SkillId { get; set; }

        [Required]
        [MaxLength(100)]
        public string SkillName { get; set; }
        #endregion
    }
}
