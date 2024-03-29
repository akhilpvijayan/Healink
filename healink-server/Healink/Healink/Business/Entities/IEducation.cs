﻿namespace Healink.Business.Entities
{
    public interface IEducation
    {
        #region properties
        long EducationId { get; set; }
        string Institution { get; set; }
        string Degree { get; set; }
        string FieldOfStudy { get; set; }
        DateTime GraduationstartDate { get; set; }
        DateTime GraduationEndDate { get; set; }
        long Userid { get; set; }
        #endregion
    }
}
