using Healink.Business.Entities;
using System.ComponentModel.DataAnnotations;

namespace Healink.Entities
{
    public class IndustryType : BaseEntity,IIndustryType
    {
        #region properties
        [Key]
        public long IndustryTypeId { get; set; }

        [Required]
        [MaxLength(100)]
        public string IndustryName { get; set; }
        #endregion
    }
}
