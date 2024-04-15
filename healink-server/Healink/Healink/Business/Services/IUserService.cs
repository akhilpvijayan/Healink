using Healink.Business.Services.Dto;
using Healink.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Healink.Business.Services
{
    public interface IUserService
    {
        #region public functions
        Task<ActionResult<IEnumerable<User>>> GetAllUsers();
        Task<List<UserDetail>> GetPersonalUsers(long userId);
        Task<List<OrganizationDetail>> GetOrganizationalUsers(long userId);
        Task<List<UserDetail>> GetAllPersonalUsers();
        Task<List<OrganizationDetail>> GetAllOrganizationalUsers();

        UserDto GetPersonalUser(int userId);

        OrganizationDetailDto GetOrganizationPersonalDetails(long userId);

        Task<bool> UpdateUser(SignUpUserDetailDto userDetails, long userId);

        bool CheckDuplicateUserName(string username);

        bool CheckDuplicateEmail(string email);
        #endregion
    }
}
