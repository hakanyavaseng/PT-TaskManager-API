using MediatR;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;
using SendGrid;
using System.IdentityModel.Tokens.Jwt;
using TaskManager.Application.Features.User.Rules;
using TaskManager.Application.Interfaces.TokenService;
using TaskManager.Domain.Entities.Identity;

namespace TaskManager.Application.Features.User.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, RegisterCommandResponse>
    {
        private readonly UserManager<AppUser> userManager;
        private readonly UserRules rules;
        private readonly ITokenService tokenService;

        public RegisterCommandHandler(UserManager<AppUser> userManager, UserRules rules, ITokenService tokenService)
        {
            this.userManager = userManager;
            this.rules = rules;
            this.tokenService = tokenService;
        }
        public async Task<RegisterCommandResponse> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            await rules.PasswordsMustMatchAndMustNotBeNull(request.Password, request.PasswordConfirmed);

            IdentityResult result = await userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                UserName = request.UserName
            }, request.Password);

            AppUser? user = await userManager.FindByEmailAsync(request.Email);

            await userManager.AddToRoleAsync(user, "USER");

            var response = new RegisterCommandResponse { IsSuccessed = result.Succeeded };
            if (result.Succeeded)
            {
                response.Message?.Add("User created successfully!");
            }
            else
            {
                foreach(var error in result.Errors)
                {
                    response.Message?.Add(error.Description);
                }
            }
            return response;
        }
    }
}
