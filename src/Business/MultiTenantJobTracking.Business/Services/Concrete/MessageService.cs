using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.CustomExceptions;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.Queries;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.Common.Results;
using MultiTenantJobTracking.DataAccess.Repositories.Abstract;
using MultiTenantJobTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Business.Services.Concrete
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository messageRepository;
        private readonly IMapper mapper;
        public MessageService(IMessageRepository messageRepository, IMapper mapper)
        {
            this.messageRepository = messageRepository;
            this.mapper = mapper;
        }

        public async Task<IResponseResult> CreateMessage(CreateMessageCommand createMessageCommand)
        {
            var message=mapper.Map<Message>(createMessageCommand);
            var result=await messageRepository.AddAsync(message);
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public async Task<IDataResult<List<MessageViewModel>>> GetChat(GetChatQuery getChatQuery)
        {
            var result = await messageRepository.AsQueryable()
       .Include(p => p.SenderUser)
       .Include(p => p.ReceiverUser)
       .Where(p =>
       (p.SenderUserId == getChatQuery.SenderId && p.ReceiverUserId == getChatQuery.ReceiverId)
       ||
       (p.SenderUserId == getChatQuery.ReceiverId && p.ReceiverUserId == getChatQuery.SenderId)
       )
       .OrderBy(p => p.SendDate)
       .ToListAsync();

            if (result.Count < 1)
            {
                return new ErrorDataResult<List<MessageViewModel>>("Mesaj bulunamadı");   
            }
            var messages = mapper.Map<List<MessageViewModel>>(result);
            return new SuccessDataResult<List<MessageViewModel>>(messages);
        }
    }
}
