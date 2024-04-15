using AutoMapper;
using Healink.Business.Entities;
using Healink.Business.Services.Dto;
using Healink.Data;
using Healink.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Healink.Business.Services.Services
{
    public class PostService : IPostService
    {
        #region properties
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        private readonly DataContext _context;
        #endregion

        #region constructor
        public PostService(IMapper mapper, ILogger<UserService> logger, DataContext context)
        {
            this._mapper = mapper;
            this._logger = logger;
            this._context = context;
        }
        #endregion
        #region public functions
        public IEnumerable<object> GetAllPosts()
        {
            try
            {
                var sqlQuery = $"Exec spGetPostDetails";
                var posts = this._context.PostDto.FromSqlRaw(sqlQuery).ToList();
                return posts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<object> GetPosts(long? userId = null)
        {
            try
            {
                var sqlQuery = $"Exec spGetPostDetails {userId}";
                var posts = this._context.PostDto.FromSqlRaw(sqlQuery).ToList();
                return posts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AddPost(AddPostDto postdetails)
        {
            using (var ms = new MemoryStream())
            {
                byte[] imageData = null;

                if (postdetails.ContentImage != null)
                {
                    await postdetails.ContentImage.CopyToAsync(ms);
                    imageData = ms.ToArray();
                }

                var imageEntity = new Post
                {
                    Content = postdetails.Content,
                    ContentImage = imageData,
                    UserId = postdetails.UserId,
                    CreatedBy = postdetails.UserId,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = postdetails.UserId,
                    ModifiedDate = DateTime.Now
                };

                _context.Posts.Add(imageEntity);
                await _context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<bool> UpdatePost(UpdatePostDto postDetails)
        {
            if(postDetails.PostId != null)
            {
                var post = await _context.Posts.FirstOrDefaultAsync(post => post.PostId == postDetails.PostId);
                if(post != null)
                {
                    post.Content = postDetails.Content;
                    if (postDetails.ContentImage != null)
                    {
                        using (var ms = new MemoryStream())
                        {
                            byte[] imageData = null;
                            await postDetails.ContentImage.CopyToAsync(ms);
                            imageData = ms.ToArray();
                            post.ContentImage = imageData;
                        }
                    }
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            return false;
        }

        public async Task<bool> DeletePost(int postId)
        {
            if(postId != null)
            {
                var post = await _context.Posts.FirstOrDefaultAsync(post=> post.PostId == postId);
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        #endregion
    }
}
