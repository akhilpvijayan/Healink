namespace Healink.Business.Entities
{
    public interface IState
    {
        #region properties
        long StateId { get; set; }
        string StateName { get; set; }
        long CountryId { get; set; }
        #endregion
    }
}
