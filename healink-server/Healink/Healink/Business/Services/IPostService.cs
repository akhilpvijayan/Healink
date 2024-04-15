using Healink.Business.Services.Dto;
using Healink.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Healink.Business.Services
{
    public interface IPostService
    {
        #region public functions
        IEnumerable<object> GetAllPosts();
        IEnumerable<object> GetPosts(long? userId = null);
        Task<bool> AddPost(AddPostDto postdetails);
        Task<bool> UpdatePost(UpdatePostDto postdetails);

        Task<bool> DeletePost(int postId);
        #endregion
    }
}
