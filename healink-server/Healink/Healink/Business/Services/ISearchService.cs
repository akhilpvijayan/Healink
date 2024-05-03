using Healink.Business.Services.Dto;
using Healink.Entities;

namespace Healink.Business.Services
{
    public interface ISearchService
    {
        IEnumerable<UserDetail> GetPersonalUsersInSearch(string query, bool isAllUsers, int skip, int take);
        IEnumerable<OrganizationDetail> GetOrganizationalUsersInSearch(string query, bool isAllUsers, int skip, int take);
        IEnumerable<PostDto> GetPostsInSearch(string query, long userId, int skip, int take);
    }
}
