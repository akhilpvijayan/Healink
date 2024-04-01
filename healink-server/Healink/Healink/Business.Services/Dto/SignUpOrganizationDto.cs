using Healink.Entities;

namespace Healink.Business.Services.Dto
{
    public class SignUpOrganizationDto : BaseEntity
    {
        public string? Username { get; set; } = null;
        public string? Email { get; set; } = null;
        public string? Password { get; set; } = null;
        public DateTime? LastLogin { get; set; } = DateTime.Now;
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool? IsVerified { get; set; } = null;
        public long RoleId { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationBio { get; set; }
        public string OrganizationWebsite { get; set; }
        public IFormFile? OrganizationLogo { get; set; } = null;
        public IFormFile? OrganizationCover { get; set; } = null;
        public long CountryId { get; set; }
        public long StateId { get; set; }
        public string Tagline { get; set; }
        public string Region { get; set; }
        public long OrganizationType { get; set; }
        public long OrganizationSize { get; set; }
        public int? FollowCount { get; set; } = 0;
        public bool? IsProfilePictureUpdated { get; set; } = false;
        public bool? IsProfileCoverUpdated { get; set; } = false;
    }
}
