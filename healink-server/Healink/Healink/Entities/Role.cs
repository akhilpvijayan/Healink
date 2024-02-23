using Healink.Business.Entities;
using System.ComponentModel.DataAnnotations;

namespace Healink.Entities
{
    public class Role : IRole
    {
        #region properties
        [Key]
        public long RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
        #endregion
    }
}
