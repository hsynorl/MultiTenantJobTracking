using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MultiTenantJobTracking.Business.Services.Abstract;
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
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        readonly IConfiguration configuration;

        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        public async Task<bool> CreateUser(CreateUserCommand createUserCommand)
        {
            var user = mapper.Map<User>(createUserCommand);
            var result=await userRepository.AddAsync(user);
            return result > 0;
        }

        public async Task<LoginViewModel> Login(LoginCommand loginCommand)
        {
            var user=await userRepository.GetSingleAsync(p=>p.EmailAddress== loginCommand.EmailAddress);
            if (user is null)
            {
                throw new Exception("Kullanıcı bulunamadı!");
            }
            if (user.Password!=loginCommand.Password)
            {
                throw new Exception("Hatalı Şifre!");
            }
            LoginViewModel loginViewModel = new LoginViewModel();   
           
            var claims = new Claim[]
          {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.EmailAddress),
            new Claim(ClaimTypes.GivenName, user.FirstName),
            new Claim(ClaimTypes.Surname, user.LastName),
            new Claim(ClaimTypes.Role,user.UserType.ToString())
          };

            var token = GenerateToken(claims);

            loginViewModel.Token = token.Item1;
            loginViewModel.TokenExpire = token.Item2;

            return loginViewModel;


        }
        private (string, DateTime) GenerateToken(Claim[] claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AuthConfig:Secret"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiryDate = DateTime.Now.AddDays(10);
            var expiry = new DateTime(expiryDate.Year, expiryDate.Month, expiryDate.Day, expiryDate.Hour, expiryDate.Minute, expiryDate.Second);


            var token = new JwtSecurityToken(claims: claims,
                                             expires: expiry,
                                             signingCredentials: creds
                                             );

            return (new JwtSecurityTokenHandler().WriteToken(token), expiry);
        }
    }
}
