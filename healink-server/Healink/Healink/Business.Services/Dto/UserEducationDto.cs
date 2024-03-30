using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Healink.Business.Services.Dto
{
    [Keyless]
    public class UserEducationDto
    {
        public bool? Current { get; set; } = null;
        public long? EducationId { get; set; } = null;
        public string Degree { get; set; }
        public string FieldOfStudy { get; set; }
        public string? GraduationDescription { get; set; } = null;
        public DateTime GraduationStartDate { get; set; }
        public DateTime? GraduationEndDate { get; set; } = null;
        public string Institution { get; set; }
        public long? OrgId { get; set; } = null;
        public byte[]? Orglogo { get; set; } = null;
        public DateTime? CreatedDate { get; set; } = null;
        public long? CreatedBy { get; set; } = null;
        public DateTime? ModifiedDate { get; set; } = null;
        public long? ModifiedBy { get; set; } = null;
    }
}
