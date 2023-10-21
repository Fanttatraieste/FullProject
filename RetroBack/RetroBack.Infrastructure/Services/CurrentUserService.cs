using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using RetroBack.Common.Identity;
using RetroBack.Domain.Entities;
using System.Security.Claims;


namespace RetroBack.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;

        }

        public async Task<CurrentUser> GetCurrentUser()
        {
            if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                return null;

            ApplicationUser user = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            return user == null || user.IsDisabledByAdmin
                ? null
                : new CurrentUser()
                {
                    UserId = user.Id,
                };
        }
    }
}
