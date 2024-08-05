using MultiTenantJobTracking.Entities.Concrete;
using System.Security.Claims;

namespace MultiTenantJobTracking.WebApi.Services
{
    public class UserHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetUserId()
        {
            var userIdClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                throw new UnauthorizedAccessException("User is not authorized.");
            }
            return Guid.Parse(userIdClaim.Value);
        }
    }

}
