using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Healink.Business.Services.Dto
{
    [Keyless]
    public class UserDetailsDto : BaseDto
    {
        #region 
        public long UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsVerified { get; set; }
        public long UserDetailId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Gender { get; set; } = null;
        public long? RoleId { get; set; } = null;
        public byte[]? ProfileImage { get; set; } = null;
        public byte[]? ProfileCover { get; set; } = null;
        public string UserBio { get; set; }
        public long CountryId { get; set; }
        public string CountryName { get; set; }
        public long StateId { get; set; }
        public string StateName { get; set; }
        public string Region { get; set; }
        public string Specialization { get; set; }
        public int ConnectionsCount { get; set; }
        #endregion
    }
}
