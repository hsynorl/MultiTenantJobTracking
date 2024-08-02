using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.Models.Commands;

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
        public async Task<IActionResult> CraeteMessage(CreateMessageCommand createMessageCommand) 
        { 
            var result=await messageService.CreateMessage(createMessageCommand);  
            return Ok(result);
        }

        [HttpPost("create-message")]
        public async Task<IActionResult> GetChats(CreateMessageCommand createMessageCommand)
        {
            var result = await messageService.CreateMessage(createMessageCommand);
            return Ok(result);
        }
    }
}
