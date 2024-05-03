using Healink.Business.Services.Dto;
using Healink.Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Healink.Entities;

namespace Healink.Controllers
{
    [ApiController]
    public class SearchController : ControllerBase
    {
        #region properties
        private readonly ISearchService _searchService;
        #endregion

        #region constructor
        public SearchController(ISearchService searchService)
        {
            this._searchService = searchService;
        }
        #endregion

        #region public functions
        [Authorize]
        [HttpGet("search/users/{query}")]
        public IEnumerable<UserDetail> GetTopPersonalUsersInSearch(string query, [FromQuery] int skip, [FromQuery] int take)
        {
            try
            {
                return _searchService.GetPersonalUsersInSearch(query, false, skip,take);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpGet("search/users/all/{query}")]
        public IEnumerable<UserDetail> GetAllPersonalUsersInSearch(string query, [FromQuery] int skip, [FromQuery] int take)
        {
            try
            {
                return _searchService.GetPersonalUsersInSearch(query, true, skip, take);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpGet("search/orgs/{query}")]
        public IEnumerable<OrganizationDetail> GetTopOrganizationalUsersInSearch(string query, [FromQuery] int skip, [FromQuery] int take)
        {
            try
            {
                return _searchService.GetOrganizationalUsersInSearch(query, false, skip, take);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpGet("search/orgs/all/{query}")]
        public IEnumerable<OrganizationDetail> GetAllOrganizationalUsersInSearch([FromQuery] int skip, [FromQuery] int take, string query)
        {
            try
            {
                return _searchService.GetOrganizationalUsersInSearch(query, true, skip, take);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpGet("search/posts/{query}")]
        public IEnumerable<PostDto> GetPostsInSearch([FromQuery] int skip, [FromQuery] int take, string query,[FromQuery] long userId)
        {
            try
            {
                return _searchService.GetPostsInSearch(query, userId, skip, take);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
