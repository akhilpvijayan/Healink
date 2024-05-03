using Healink.Business.Services.Dto;

namespace Healink.Business.Services
{
    public interface IChatService
    {
        List<ChatsDto> GetChats(long userId);
        List<ChatsDto> GetMessages(int skip, int take, long chatId, long userId);
        long isChatExists(long userId, long targetId);
    }
}
