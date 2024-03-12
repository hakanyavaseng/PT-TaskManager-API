using System.IdentityModel.Tokens.Jwt;
using TaskManager.Domain.Entities.Identity;

namespace TaskManager.Application.Interfaces.TokenService
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> CreateToken(AppUser user, IList<string> roles);
    }
}
