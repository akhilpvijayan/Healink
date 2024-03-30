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
        [HttpGet("posts")]
        public async Task<IActionResult> GetAllPosts()
        {
            try
            {
                var posts =  _postService.GetAllPosts();
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
        #endregion
    }
}
