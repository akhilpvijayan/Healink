namespace Healink.Business.Services
{
    public interface IAuthorizationService
    {
        #region properties
        Task<string> generateToken(string username, string password);
        #endregion
    }
}
