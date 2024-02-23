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

        public async Task<ActionResult<IEnumerable<UserDto>>> GetUser(int userId)
        {
            try
            {
                FormattableString sqlQuery = $"spGetUserDetails {userId}";
                return await this._context.Database.ExecuteSqlAsync(sqlQuery);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
