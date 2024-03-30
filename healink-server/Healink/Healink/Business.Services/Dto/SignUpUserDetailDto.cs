using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Healink.Entities;

namespace Healink.Business.Services.Dto
{
    public class SignUpUserDetailDto : BaseEntity
    {
        public string? Username { get; set; } = null;
        public string? Email { get; set; } = null;
        public string? Password { get; set; } = null;
        public DateTime? LastLogin { get; set; } = DateTime.Now;
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool? IsVerified { get; set; } = null;
        public long RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IFormFile? ProfileImage { get; set; } = null;
        public IFormFile? ProfileCover { get; set; } = null;
        public string? UserBio { get; set; } = null;
        public string? Gender { get; set; } = null;
        public long CountryId { get; set; }
        public long StateId { get; set; }
        public string Region { get; set; }
        public string Specialization { get; set; }
        public int? ConnectionsCount { get; set; } = 0;
        public bool? isProfilePictureUpdated { get; set; } = false;
        public bool? isProfileCoverUpdated { get; set; } = false;
    }
}
