using Healink.Entities;

namespace Healink.Business.Services
{
    public interface IStateService
    {
        List<State> GetStateByCountryId(long countryId);
    }
}
