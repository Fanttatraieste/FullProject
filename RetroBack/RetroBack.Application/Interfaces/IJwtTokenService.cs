using RetroBack.Domain.Entities;

namespace RetroBack.Application.Interfaces
{
    public interface IJwtTokenService
    {
        string CreateToken(ApplicationUser user, string[] roles);
    }
}
