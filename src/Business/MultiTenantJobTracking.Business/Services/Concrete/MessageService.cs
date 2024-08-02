using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.CustomExceptions;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.Queries;
using MultiTenantJobTracking.Common.Models.ViewModels;
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

        public async Task<bool> CreateMessage(CreateMessageCommand createMessageCommand)
        {
            var message=mapper.Map<Message>(createMessageCommand);
            var result=await messageRepository.AddAsync(message);
            return result > 0;
        }

        public async Task<List<MessageViewModel>> GetChat(GetChatQuery getChatQuery)
        {
            var result = await messageRepository.AsQueryable().Include(p=>p.SenderUser).Include(p => p.ReceiverUser).Where(p => p.SenderUserId== getChatQuery.SenderId || p.ReceiverUserId==getChatQuery.ReceiverId).ToListAsync();
            if (result.Count < 1)
            {
                throw new NotFoundException("Mesaj bulunamadı");
            }
            var messages = mapper.Map<List<MessageViewModel>>(result);
            return messages;
        }
    }
}
