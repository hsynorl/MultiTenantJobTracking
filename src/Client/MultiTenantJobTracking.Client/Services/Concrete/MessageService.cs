using MultiTenantJobTracking.Client.Services.Abstraction;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.Queries;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.Common.Results;

namespace MultiTenantJobTracking.Client.Services.Concrete
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IResponseResult> CreateMessage(CreateMessageCommand createMessageCommand)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<MessageViewModel>>> GetChat(GetChatQuery getChatQuery)
        {
            throw new NotImplementedException();
        }
    }


}
