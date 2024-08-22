using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Results;

namespace MultiTenantJobTracking.Client.Services.Abstraction
{
    public interface IMessageService
    {
        Task<IResponseResult> CreateMessage(CreateMessageCommand createMessageCommand);
    }


}
