namespace Healink.Business.Entities
{
    public interface IJob
    {
        #region properties
        long JobId { get; set; }
        string JobTitle { get; set; }
        string JobDescription { get; set; }
        string JobUrl { get; set; }
        string Location { get; set; }
        string Salary { get; set; }
        DateTime TimeStamp { get; set; }
        DateTime Deadline { get; set; }
        long UserId { get; set; }
        long OrganizationDetailId { get; set; }
        #endregion
    }
}
