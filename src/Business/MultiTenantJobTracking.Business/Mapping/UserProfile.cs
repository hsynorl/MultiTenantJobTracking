using AutoMapper;
using MultiTenantJobTracking.Common.Enums;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.Entities.Concrete;

namespace MultiTenantJobTracking.Business.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserCommand, User>()
                .ForMember(p=>p.UserType,y=>y.MapFrom(z=>UserType.User));
            CreateMap<CreateDepartmentAdminUserCommand, User>()
             .ForMember(p => p.UserType, y => y.MapFrom(z => UserType.DepartmanAdmin));
            CreateMap<CreateTenantAdminUserCommand, User>()
             .ForMember(p => p.UserType, y => y.MapFrom(z => UserType.TenantAdmin));
            CreateMap<LoginCommand, User>();
            CreateMap<User,UserViewModel>().ReverseMap();

        }
    }

}
