using AutoMapper;
using Healink.Business.Services.Dto;
using Healink.Data;
using Healink.Entities;
using Microsoft.EntityFrameworkCore;

namespace Healink.Business.Services.Services
{
    public class ChatService : IChatService
    {
        #region properties
        private readonly IMapper _mapper;
        private readonly ILogger<ChatService> _logger;
        private readonly DataContext _context;
        #endregion

        #region constructor
        public ChatService(IMapper mapper, ILogger<ChatService> logger, DataContext context)
        {
            this._mapper = mapper;
            this._logger = logger;
            this._context = context;
        }
        #endregion

        #region public functions

        public List<ChatsDto> GetChats(long userId)
        {
            var sqlQuery = $"Exec spGetChatDetails {userId}";
            return this._context.ChatsDto.FromSqlRaw(sqlQuery).AsEnumerable().ToList();
        }

        public List<ChatsDto> GetMessages(int skip, int take, long chatId, long userId)
        {
            var sqlQuery = $"Exec spGetMessageDetails {skip}, {take}, {chatId}, {userId}";
            return this._context.ChatsDto.FromSqlRaw(sqlQuery).AsEnumerable().ToList();
        }

        public long isChatExists(long userId, long targetId)
        {
            var chatUser = _context.Chats.FirstOrDefault(x => (x.SendUserId == userId && x.ReceivedUserId == targetId) || (x.ReceivedUserId == userId && x.SendUserId == targetId));
            if(chatUser != null)
            {
                return chatUser.ChatId;
            }
            return 0;
        }
        #endregion
    }
}
