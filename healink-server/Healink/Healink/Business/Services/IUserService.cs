using Healink.Business.Services.Dto;
using Healink.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Healink.Business.Services
{
    public interface IUserService
    {
        #region public functions
        Task<ActionResult<IEnumerable<User>>> GetAllUsers();

        IEnumerable<object> GetUser(int userId);

        bool CheckDuplicateUserName(string username);
        #endregion
    }
}
