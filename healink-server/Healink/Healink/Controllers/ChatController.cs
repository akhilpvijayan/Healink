using Healink.Business.Services;
using Healink.Business.Services.Dto;
using LazyCache;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Healink.Controllers
{
    [ApiController]
    public class ChatController : ControllerBase
    {
        #region properties
        private readonly IChatService _chatService;
        #endregion

        #region constructor
        public ChatController(IChatService chatService)
        {
            this._chatService = chatService;
        }
        #endregion

        #region public functions
        [Authorize]
        [HttpGet("chats/{userId}")]
        public List<ChatsDto> GetChats(long userId)
        {
            return this._chatService.GetChats(userId);
        }

        [Authorize]
        [HttpGet("messages/{chatId}/{userId}")]
        public List<ChatsDto> GetMessages([FromQuery] int skip, [FromQuery] int take, long chatId, long userId)
        {
            return this._chatService.GetMessages(skip, take, chatId, userId);
        }

        [Authorize]
        [HttpGet("chats/exists/{userId}/{targetId}")]
        public long isChatExists(long userId, long targetId)
        {
            return this._chatService.isChatExists(userId, targetId);
        }
        #endregion
    }
}
