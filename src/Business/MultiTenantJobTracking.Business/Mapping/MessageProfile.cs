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
                .ForMember(p=>p.SendDate,y=>y.MapFrom(z=>DateTime.Now))
                .ReverseMap();
                CreateMap<Message, MessageViewModel>()
                .ForMember(p=>p.SenderId,y=>y.MapFrom(z=>z.SenderUserId))
                .ForMember(p=>p.ReceiverId,y=>y.MapFrom(z=>z.ReceiverUserId))
                .ForMember(p=>p.SenderName,y=>y.MapFrom(z=>z.SenderUser.FirstName))
                .ForMember(p=>p.ReceiverName,y=>y.MapFrom(z=>z.ReceiverUser.FirstName))
                .ReverseMap();
        }
    }
}
