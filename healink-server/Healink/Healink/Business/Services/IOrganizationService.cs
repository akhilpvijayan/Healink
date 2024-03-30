using Healink.Entities;

namespace Healink.Business.Services
{
    public interface IOrganizationService
    {
        #region properties
        IEnumerable<object> GetOrgainsationsForSignup();
        IEnumerable<object> GetEducationalOrganizations();
        #endregion
    }
}
