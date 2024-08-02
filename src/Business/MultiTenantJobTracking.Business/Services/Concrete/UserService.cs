using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.CustomExceptions;
using MultiTenantJobTracking.Common.Enums;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.DataAccess.Repositories.Abstract;
using MultiTenantJobTracking.Entities.Concrete;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MultiTenantJobTracking.Business.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IDepartmentAdminService departmentAdminService;
        private readonly ITenantUserService tenantUserService;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        readonly IConfiguration configuration;

        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration, ITenantUserService tenantUserService, IDepartmentAdminService departmentAdminService)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.configuration = configuration;
            this.tenantUserService = tenantUserService;
            this.departmentAdminService = departmentAdminService;
        }

        public async Task<bool> CreateDepartmentAdminUser(CreateDepartmentAdminUserCommand createDepartmentAdminUserCommand)
        {

            var existEmail = await userRepository.GetSingleAsync(p => p.EmailAddress == createDepartmentAdminUserCommand.EmailAddress);
            if (existEmail is not null)
            {
                throw new ExistingRecordException("Bu email adresine sahip bir kullanıcı var");
            }
            
            var user = mapper.Map<User>(createDepartmentAdminUserCommand);
            user.UserType = UserType.DepartmanAdmin;
            var result = await userRepository.AddAsync(user);
            if (result > 0)
            {
                var deartmentAdminResult = await departmentAdminService.CreateDepartmentAdmin(new() { DepartmentId = createDepartmentAdminUserCommand.DepartmentId, UserId = user.Id });
                return deartmentAdminResult;
            }
            return false;
        }

        public async Task<bool> CreateTenantAdminUser(CreateTenantAdminUserCommand createTenantAdminUserCommand)
        {
            var existEmail = await userRepository.GetSingleAsync(p => p.EmailAddress == createTenantAdminUserCommand.EmailAddress);
            if (existEmail is not null)
            {
                throw new ExistingRecordException("Bu email adresine sahip bir kullanıcı var");
            }
            var user = mapper.Map<User>(createTenantAdminUserCommand);
            user.UserType=UserType.TenantAdmin;
            var result = await userRepository.AddAsync(user);
            if (result > 0)
            {
                var tenantAdminResult = await tenantUserService.CreateTenantUser(new() { TenantId = createTenantAdminUserCommand.TenantId, UserId = user.Id });
                return tenantAdminResult;
            }
            return false;
        }

        public async Task<bool> CreateUser(CreateUserCommand createUserCommand)
        {
            var existEmail=await userRepository.GetSingleAsync(p=>p.EmailAddress==createUserCommand.EmailAddress);
            if (existEmail is not null )
            {
                throw new ExistingRecordException("Bu email adresine sahip bir kullanıcı var");
            }
            var user = mapper.Map<User>(createUserCommand);
            user.UserType = UserType.User;
            var result = await userRepository.AddAsync(user);
            if (result>0)
            {
                var tenantUserResult=await tenantUserService.CreateTenantUser(new() { TenantId=createUserCommand.TenantId , UserId=user.Id});
                return tenantUserResult;
            }
            return false;
        }

        public async Task<LoginViewModel> Login(LoginCommand loginCommand)
        {

            var user = await GetUserAsync(loginCommand.EmailAddress);
            ValidateUser(user, loginCommand.Password);

            if (user.UserType != UserType.GeneralAdmin)
            {
                ValidateLicence(user);
            }

            var loginViewModel = CreateLoginViewModel(user);

            return loginViewModel;

        }
        private async Task<User> GetUserAsync(string emailAddress)
        {
            return await userRepository.AsQueryable()
                .Include(p => p.TenantUser)
                    .ThenInclude(p => p.Tenant)
                    .ThenInclude(p => p.Licence)
                .Include(p => p.DepartmentUser)
                    .ThenInclude(p => p.Department)
                    .ThenInclude(p => p.Tenant)
                    .ThenInclude(p => p.Licence)
                .FirstOrDefaultAsync(p => p.EmailAddress == emailAddress);
        }
        private void ValidateUser(User user, string password)
        {
            if (user is null)
            {
                throw new NotFoundException("Kullanıcı bulunamadı!");
            }
            if (user.Password != password)
            {
                throw new InvalidCredentialsException("Hatalı Şifre!");
            }
        }
        private void ValidateLicence(User user)
        {
            var licence = user.UserType switch
            {
                UserType.TenantAdmin => user.TenantUser?.Tenant?.Licence,
                _ => user.DepartmentUser?.Department?.Tenant?.Licence,
            };
            if (licence is null)
            {
                throw new LicenseExpiredException("Lisan satın alınız");

            }
            if (licence.ExpireDate < DateTime.Now)
            {
                throw new LicenseExpiredException();
            }
        }

        private LoginViewModel CreateLoginViewModel(User user)
        {
            var claims = new[]
            {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Email, user.EmailAddress),
        new Claim(ClaimTypes.GivenName, user.FirstName),
        new Claim(ClaimTypes.Surname, user.LastName),
        new Claim(ClaimTypes.Role, user.UserType.ToString())
    };

            var token = GenerateToken(claims);

            return new LoginViewModel
            {
                Token = token.Item1,
                TokenExpire = token.Item2
            };
        }

        private (string, DateTime) GenerateToken(Claim[] claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AuthConfig:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiryDate = DateTime.Now.AddDays(10);
            var expiry = new DateTime(expiryDate.Year, expiryDate.Month, expiryDate.Day, expiryDate.Hour, expiryDate.Minute, expiryDate.Second);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: expiry,
                signingCredentials: creds
            );

            return (new JwtSecurityTokenHandler().WriteToken(token), expiry);
        }

        public async Task<List<UserViewModel>> GetUsersWithoutDepartments(Guid TenantId)
        {
            var users=await userRepository.AsQueryable().Where(p=>p.TenantUser.Tenant.Id == TenantId&& p.UserType==UserType.User).ToListAsync();
            var withoutDepartmentUsers = users
       .Where(p => p.DepartmentUser == null)
       .ToList();
            if (withoutDepartmentUsers.Count<1)
            {
                throw new NotFoundException("Her hangi bir department'a üye olmayan kullanıcı bulunamadı");
            }
            var userViewModels = mapper.Map<List<UserViewModel>>(withoutDepartmentUsers);
            return userViewModels;  
        }
    }
}
