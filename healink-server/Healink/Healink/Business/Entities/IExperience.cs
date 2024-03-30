namespace Healink.Business.Entities
{
    public interface IExperience
    {
        #region properties
        long ExperienceId { get; set; }
        string Title { get; set; }
        string Company { get; set; }
        string Location { get; set; }
        DateTime StartDate { get; set; }
        DateTime? EndDate { get; set; }
        string Description { get; set; }
        long UserId { get; set; }
        long? CompanyId { get; set; }
        #endregion
    }
}
