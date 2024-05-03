using Healink.Business.Services.Dto;
using Healink.Data;
using Healink.Entities;
using Microsoft.EntityFrameworkCore;

namespace Healink.Business.Services.Services
{
    public class SearchService : ISearchService
    {
        #region properties
        private readonly DataContext _context;
        #endregion

        #region constructor
        public SearchService(DataContext context)
        {
            this._context = context;
        }
        #endregion
        #region public functions

        public IEnumerable<UserDetail> GetPersonalUsersInSearch(string query, bool isAllUsers, int skip, int take)
        {
            if (isAllUsers)
            {
                var sqlQuery = $"Exec spGetSearchResultsPersonalUsers {true}, {query}, {take}, {skip}";
                return this._context.UserDetails.FromSqlRaw(sqlQuery).AsEnumerable();
            }
            else
            {
                var sqlQuery = $"Exec spGetSearchResultsPersonalUsers {false}, {query}, {take}, {skip}";
                return this._context.UserDetails.FromSqlRaw(sqlQuery).AsEnumerable();
            }
        }

        public IEnumerable<OrganizationDetail> GetOrganizationalUsersInSearch(string query, bool isAllUsers, int skip, int take)
        {
            if (isAllUsers)
            {
                var sqlQuery = $"Exec spGetSearchResultsOrganizationalUsers {true}, {query}, {take}, {skip}";
                return this._context.OrganizationDetails.FromSqlRaw(sqlQuery).AsEnumerable();
            }
            else
            {
                var sqlQuery = $"Exec spGetSearchResultsOrganizationalUsers {false}, {query}, {take}, {skip}";
                return this._context.OrganizationDetails.FromSqlRaw(sqlQuery).AsEnumerable();
            }
        }

        public IEnumerable<PostDto> GetPostsInSearch(string query, long userId, int skip, int take)
        {
            var sqlQuery = $"Exec spGetSearchResultsPosts {query}, {userId}, {take}, {skip}";
            return this._context.PostDto.FromSqlRaw(sqlQuery).AsEnumerable();
        }
        #endregion
    }
}
