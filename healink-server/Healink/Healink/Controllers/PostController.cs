using Healink.Business.Services;
using Healink.Business.Services.Dto;
using Healink.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Healink.Controllers
{
    [ApiController]
    public class PostController : ControllerBase
    {
        #region properties
        private readonly IPostService _postService;
        #endregion

        #region constructor
        public PostController(IPostService postService)
        {
            this._postService = postService;
        }
        #endregion

        #region public functions
        [Authorize]
        [HttpGet("posts/all/{userId}")]
        public async Task<IActionResult> GetAllPosts([FromQuery] int skip, [FromQuery] int take, long userId)
        {
            try
            {
                var posts =  _postService.GetAllPosts(skip, take, userId);
                if (posts != null)
                {
                    return Ok(posts);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpGet("posts/{userId}")]
        public async Task<IActionResult> GetPosts([FromQuery] int skip, [FromQuery] int take, long userId)
        {
            try
            {
                var posts = _postService.GetPosts(skip, take, userId);
                if (posts != null)
                {
                    return Ok(posts);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpGet("post/{postId}")]
        public async Task<IActionResult> GetPost(int postId)
        {
            try
            {
                var posts = _postService.GetPost(postId);
                if (posts != null)
                {
                    return Ok(posts);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpPost("post")]
        public IActionResult AddPost([FromForm] AddPostDto postdetails)
        {
            try
            {
                var post = this._postService.AddPost(postdetails).Result;
                if (post)
                {
                    return Ok(post);
                }
                return BadRequest();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpPut("post")]
        public IActionResult UpdatePost([FromForm] UpdatePostDto postdetails)
        {
            var updatedPost = this._postService.UpdatePost(postdetails);

            if (updatedPost.Result)
            {
                return Ok(updatedPost.Result);
            }
            return NotFound();
        }

        [HttpDelete("post/{postId}")]
        public IActionResult DeletePost(int postId)
        {
            var deletedPost = this._postService.DeletePost(postId);

            if (deletedPost.Result)
            {
                return Ok(deletedPost.Result);
            }

            return NotFound();
        }

        [Authorize]
        [HttpGet("comments/{postId}")]
        public async Task<IActionResult> GetComments([FromQuery] int skip, [FromQuery] int take, long postId)
        {
            try
            {
                var posts = _postService.GetComments(skip, take, postId);
                if (posts != null)
                {
                    return Ok(posts);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
            #endregion
        }
}
