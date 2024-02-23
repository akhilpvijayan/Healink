using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Healink.Entities
{
    public class UserSkill
    {
        #region properties
        [Key]
        public long UserSkillId { get; set; }

        [Required]
        [ForeignKey("User")]
        public long Userid { get; set; }

        [Required]
        [ForeignKey("Skill")]
        public long SkillId { get; set; }
        #endregion

        public virtual User User { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
