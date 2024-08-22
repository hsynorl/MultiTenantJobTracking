using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.Queries;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.Common.Results;

namespace MultiTenantJobTracking.Client.Services.Abstraction
{
    public interface IMessageService
    {
        Task<IResponseResult> CreateMessage(CreateMessageCommand createMessageCommand);
        Task<IDataResult<List<MessageViewModel>>> GetChat(GetChatQuery getChatQuery);
    }


}
