using AutoMapper;
using Healink.Business.Services.Services;
using Healink.Data;
using Healink.Entities;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Healink.Helper
{
    public class ChatHub : Hub
    {
        #region properties
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        private readonly DataContext _context;
        #endregion

        #region constructor
        public ChatHub(IMapper mapper, ILogger<UserService> logger, DataContext context)
        {
            this._mapper = mapper;
            this._logger = logger;
            this._context = context;
        }
        #endregion
        #region public functions
        public async Task SendMessage(long user, string message, long targetUser)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message, targetUser);

            var chatUser = await _context.Chats.FirstOrDefaultAsync(x => (x.SendUserId == user && x.ReceivedUserId == targetUser) || (x.ReceivedUserId == user && x.SendUserId == targetUser));

            if(chatUser == null)
            {
                chatUser = new Chats
                {
                    SendUserId = user,
                    ReceivedUserId = targetUser,
                    CreatedDate = DateTime.Now,
                    CreatedBy = user,
                    ModifiedBy = user,
                    ModifiedDate = DateTime.Now
                };

                await _context.Chats.AddAsync(chatUser);
                await _context.SaveChangesAsync();
            }

            var messageEntity = new Message
            {
                MessageContent = message,
                Timestamp = DateTime.Now,
                IsRead = false,
                SenderId  = user, 
                ReceiverId = targetUser,
                ChatId = chatUser.ChatId
            };
            await _context.Messages.AddAsync(messageEntity);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
