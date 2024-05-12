using AutoMapper;
using Healink.Business.Services.Services;
using Healink.Data;
using Healink.Entities;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Connection = Healink.Entities.Connection;

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
            byte[] aesKey = null;
            if (chatUser == null)
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
                aesKey = Encryptor.GenerateAesKey();
            }
            else
            {
                aesKey = _context.Messages.FirstOrDefault(x => x.ChatId == chatUser.ChatId).MessageAesKey;
            }

            var messageEntity = new Message
            {
                MessageContent = Encryptor.EncryptMessage(message, aesKey),
                Timestamp = DateTime.Now,
                IsRead = false,
                SenderId  = user, 
                ReceiverId = targetUser,
                ChatId = chatUser.ChatId,
                MessageAesKey = aesKey
            };
            await _context.Messages.AddAsync(messageEntity);
            await _context.SaveChangesAsync();
        }

        public async Task LikePost(long user, long postId, long targetUser, bool isRemoveLike)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => (x.PostId == postId));
            await Clients.All.SendAsync("Likes", user, postId, isRemoveLike ? post.LikeCount - 1 : post.LikeCount + 1);
            if (post != null && !isRemoveLike)
            {
                post.LikeCount += 1;
                var likeEntity = new Likes
                {
                    PostId = postId,
                    UserId = user
                };
                await _context.Likes.AddAsync(likeEntity);
            }
            else
            {
                post.LikeCount -= 1;
                var likeEntity = await _context.Likes.FirstOrDefaultAsync(x => x.PostId == postId && x.UserId == user);
                if (likeEntity != null)
                {
                    _context.Likes.Remove(likeEntity);
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task PostComment(long user, long postId, long targetUser, string commentContent, bool isDelete, long commentId)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(x => (x.CommentId == commentId));
            bool isUpdate = false;
            if (comment != null)
            {
                if (isDelete)
                {
                    _context.Comments.Remove(comment);
                }
                else
                {
                    comment.Content = commentContent;
                    isUpdate = true;
                }
            }
            else
            {
                comment = new Comment
                {
                    Content = commentContent,
                    TimeStamp = DateTime.Now,
                    UserId = user,
                    PostId= postId,
                    CreatedBy = user,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = user,
                    ModifiedDate = DateTime.Now,
                };

                await _context.Comments.AddAsync(comment);
            }
            await _context.SaveChangesAsync();
            await Clients.All.SendAsync("Comments", isDelete, comment, isUpdate);
        }

        public async Task ConnectionRequest(long senderId, long receiverId, bool isFromTargetUser, Connection? connection = null)
        {
            if (!isFromTargetUser)
            {
                connection = new Connection
                {
                    SenderId = senderId,
                    ReceiverId = receiverId,
                    RequestedDate = DateTime.Now,
                    Status = 2,//Pending
                };
                await _context.Connections.AddAsync(connection);
                await _context.SaveChangesAsync();
                await Clients.All.SendAsync("Connection", connection);
            }
            else
            {
                if(connection.ConnectionId != null)
                {
                    var connect = _context.Connections.FirstOrDefault(x => x.ConnectionId == connection.ConnectionId);
                    connect = connection;
                    connect.AcceptedDate = DateTime.Now;
                    await _context.SaveChangesAsync();
                    await Clients.All.SendAsync("Connection", connect);
                }
            }
        }
        #endregion
    }
}
