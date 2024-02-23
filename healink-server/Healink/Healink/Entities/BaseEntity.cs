using Healink.Business.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Healink.Entities
{
    public class BaseEntity : IBaseEntity
    {
        #region properties
        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public long CreatedBy { get; set; }

        [Required]
        public DateTime ModifiedDate { get; set; }

        [Required]

        public long ModifiedBy { get; set; }
        #endregion
    }
}
