using Healink.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Healink.Business.Services.Dto
{
    [Keyless]
    public class UserExperienceDto
    {
        public long? ExperienceId { get; set; } = null;
        public string Company { get; set; }
        public string Title { get; set; }
        public long? CompanyId { get; set; } = null;
        public bool? Current { get; set; }
        public string? Description { get; set; } = null;
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } = null;
        public string? OrgCompanyName { get; set; } = null;
        public byte[]? CompanyLogo { get; set; } = null;
        public DateTime? CreatedDate { get; set; } = null;
        public long? CreatedBy { get; set; } = null;
        public DateTime? ModifiedDate { get; set; } = null;
        public long? ModifiedBy { get; set; } = null;
    }
}
