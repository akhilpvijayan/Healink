namespace Healink.Business.Entities
{
    public interface IBaseEntity
    {
        #region properties
        DateTime CreatedDate { get; set; }
        long CreatedBy { get; set; }
        DateTime ModifiedDate { get; set; }
        long ModifiedBy { get; set; }
        #endregion
    }
}
