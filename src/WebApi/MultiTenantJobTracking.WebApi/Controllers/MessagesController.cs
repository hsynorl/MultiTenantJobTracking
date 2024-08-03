using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.Enums;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.Queries;

namespace MultiTenantJobTracking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService messageService;

        public MessagesController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        [HttpPost("create-message")]
        [Authorize(Roles = $"{nameof(UserType.User)},{nameof(UserType.DepartmanAdmin)}")]
        public async Task<IActionResult> CraeteMessage(CreateMessageCommand createMessageCommand) 
        { 
            var result=await messageService.CreateMessage(createMessageCommand);  
            return Ok(result);
        }

        [HttpPost("get-chat")]
        [Authorize(Roles = $"{nameof(UserType.User)},{nameof(UserType.DepartmanAdmin)}")]
        public async Task<IActionResult> GetChats([FromQuery]Guid SenderId, [FromQuery] Guid ReceiverId)
        {
            var result = await messageService.GetChat(new GetChatQuery
            {
                ReceiverId= ReceiverId,
                SenderId= SenderId
            });
            return Ok(result);
        }
    }
}
