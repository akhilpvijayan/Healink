using AutoMapper;
using Healink.Business.Services.Dto;
using Healink.Data;
using Healink.Entities;
using Healink.Helper;
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
            var result = this._context.ChatsDto.FromSqlRaw(sqlQuery).AsEnumerable().ToList();
            foreach (var chat in result)
            {
                chat.MessageContent = Encryptor.DecryptMessage(chat.EncryptedMessageContent, _context.Messages.FirstOrDefault(x => x.ChatId == chat.ChatId).MessageAesKey);
            }
            return result;
        }

        public List<ChatsDto> GetMessages(int skip, int take, long chatId, long userId)
        {
            var sqlQuery = $"Exec spGetMessageDetails {skip}, {take}, {chatId}, {userId}";
            var result = this._context.ChatsDto.FromSqlRaw(sqlQuery).AsEnumerable().ToList();
            foreach(var chat in result)
            {
                chat.MessageContent = Encryptor.DecryptMessage(chat.EncryptedMessageContent, _context.Messages.FirstOrDefault(x=>x.ChatId == chatId).MessageAesKey);
            }
            return result;
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
