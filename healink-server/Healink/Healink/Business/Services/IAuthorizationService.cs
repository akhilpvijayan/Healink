using Healink.Business.Services.Dto;
using System.Security.Claims;

namespace Healink.Business.Services
{
    public interface IAuthorizationService
    {
        #region properties
        Task<Tuple<string, string, long>> GenerateToken(string username, string password);
        Task<Tuple<string, string>> Refresh(TokenApiDto tokenApiDto);
        Task<string> CreateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        #endregion
    }
}
