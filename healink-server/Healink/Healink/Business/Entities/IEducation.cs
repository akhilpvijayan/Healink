namespace Healink.Business.Entities
{
    public interface IEducation
    {
        #region properties
        long EducationId { get; set; }
        string Institution { get; set; }
        string Degree { get; set; }
        string FieldOfStudy { get; set; }
        DateTime GraduationstartDate { get; set; }
        DateTime? GraduationEndDate { get; set; }
        long UserId { get; set; }
        long? OrgId { get; set; }
        string GraduationDescription { get; set; }
        #endregion
    }
}
