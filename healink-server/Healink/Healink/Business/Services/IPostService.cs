using Healink.Business.Services.Dto;
using Healink.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Healink.Business.Services
{
    public interface IPostService
    {
        #region public functions
        IEnumerable<object> GetAllPosts(int skip, int take, long userId);
        IEnumerable<object> GetPosts(int skip, int take, long userId);
        IEnumerable<object> GetPost(int postId);
        Task<bool> AddPost(AddPostDto postdetails);
        Task<bool> UpdatePost(UpdatePostDto postdetails);
        Task<bool> DeletePost(int postId);
        IEnumerable<object> GetComments(int skip, int take, long postId);
        #endregion
    }
}
