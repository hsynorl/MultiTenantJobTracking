using AutoMapper;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Business.Mapping
{
    public class MessageProfile:Profile
    {
        public MessageProfile()
        {
                CreateMap<CreateMessageCommand,Message>()
                .ForMember(p=>p.ReceiverUserId,y=>y.MapFrom(z=>z.ReceiverId))
                .ForMember(p=>p.SenderUserId,y=>y.MapFrom(z=>z.SenderId))
                .ForMember(p=>p.Content,y=>y.MapFrom(z=>z.Content))
                .ForMember(p=>p.SendDate,y=>y.MapFrom(z=>DateTime.Now))
                .ReverseMap();
                CreateMap<MessageViewModel,Message>()
                .ForMember(p=>p.SenderUserId,y=>y.MapFrom(z=>z.SenderId))
                .ForMember(p=>p.ReceiverUserId,y=>y.MapFrom(z=>z.ReceiverId))

                .ForMember(p=>p.SenderUser.FirstName,y=>y.MapFrom(z=>z.SenderName))
                .ForMember(p=>p.ReceiverUser.FirstName,y=>y.MapFrom(z=>z.ReceiverName))
                
                .ForMember(p=>p.Content,y=>y.MapFrom(z=>z.Content))
                .ReverseMap();
        }
    }
}
