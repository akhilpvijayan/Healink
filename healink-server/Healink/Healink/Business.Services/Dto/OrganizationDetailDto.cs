using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Healink.Business.Services.Dto
{
    [Keyless]
    public class OrganizationDetailDto : BaseDto
    {
        public long UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public long RoleId { get; set; }
        public string RoleName { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsVerified { get; set; }
        public long OrganizationDetailId { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationWebsite { get; set; }
        public string OrganizationSize { get; set; }
        public byte[]? OrganizationLogo { get; set; } = null;
        public byte[]? OrganizationCover { get; set; } = null;
        public string OrganizationBio { get; set; }
        public long CountryId { get; set; }
        public string CountryName { get; set; }
        public long StateId { get; set; }
        public string StateName { get; set; }
        public string Region { get; set; }
        public string IndustryName { get; set; }
        public int FollowCount { get; set; }
        public string TagLine { get; set; }
    }
}
