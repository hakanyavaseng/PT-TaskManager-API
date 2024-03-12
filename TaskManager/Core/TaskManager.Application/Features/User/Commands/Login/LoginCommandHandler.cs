using MediatR;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using TaskManager.Application.Interfaces.TokenService;
using TaskManager.Domain.Entities.Identity;

namespace TaskManager.Application.Features.User.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly UserManager<AppUser> userManager;
        private readonly ITokenService tokenService;

        public LoginCommandHandler(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            this.userManager = userManager;
            this.tokenService = tokenService;
        }
        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser? user = await userManager.FindByEmailAsync(request.Email);
            bool checkPassword = await userManager.CheckPasswordAsync(user, request.Password);

            if (!checkPassword)
                throw new Exception("Password is wrong!");
            

            IList<string> roles = await userManager.GetRolesAsync(user);
            JwtSecurityToken token = await tokenService.CreateToken(user, roles);
            string _token = new JwtSecurityTokenHandler().WriteToken(token);

            await userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);


            return new LoginCommandResponse()
            {
                Token = _token,
            };
        }
    }
}
