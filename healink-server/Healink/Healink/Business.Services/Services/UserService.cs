using AutoMapper;
using Healink.Business.Services.Dto;
using Healink.Data;
using Healink.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Healink.Business.Services.Services
{
    public class UserService : IUserService
    {
        #region properties
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        private readonly DataContext _context;
        #endregion

        #region constructor
        public UserService(IMapper mapper, ILogger<UserService> logger, DataContext context)
        {
            this._mapper = mapper;
            this._logger = logger;
            this._context = context;
        }
        #endregion
        //this.logger.LogInformation('Start');

        #region public functions
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            return await this._context.Users.ToListAsync();
        }

        public IEnumerable<object> GetUser(int userId)
        {
            try
            {
                var userRole = this._context.Users.FirstOrDefault(x => x.UserId == userId).RoleId;
                bool isOrganizationalUser = false;
                var sqlQuery = $"Exec spGetUserDetails {userId}, {isOrganizationalUser}";
                if (userRole != null && userRole == 3)
                {
                    isOrganizationalUser = true;
                    sqlQuery = $"Exec spGetUserDetails {userId}, {isOrganizationalUser}";
                    return this._context.OrganizationDetailDto.FromSqlRaw(sqlQuery).ToList();
                }
                return this._context.UserDto.FromSqlRaw(sqlQuery).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckDuplicateUserName(string username)
        {
            bool isUsernameExist = false;
            var user = this._context.Users.FirstOrDefault(x => x.Username == username);
            if(user != null)
            {
                isUsernameExist = true;
                return isUsernameExist;
            }
            return isUsernameExist;
        }
        #endregion
    }
}
