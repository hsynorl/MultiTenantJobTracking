using AutoMapper;
using MultiTenantJobTracking.Common.Models.User.Command;
using MultiTenantJobTracking.Common.Models.User.ViewModel;
using MultiTenantJobTracking.Entities.Concrete;

namespace MultiTenantJobTracking.Business.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User,CreateUserCommand>();
            CreateMap<User,UserViewModel>();

        }
    }

}
