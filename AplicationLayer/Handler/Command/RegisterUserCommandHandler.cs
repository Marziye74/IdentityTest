using AplicationLayer.Common;
using AplicationLayer.Interfaces;
using AplicationLayer.Request.Command;
using DomainLayer.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace AplicationLayer.Handler.Command
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest, Result>
    {
        private UserManager<User> _userManager;
        private readonly ILoginService _loginService;
        public RegisterUserCommandHandler(UserManager<User> userManager, ILoginService loginService)
        {
            _userManager = userManager;
            _loginService = loginService;
        }

        public async Task<Result> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            
                var currentEmail = await _userManager.FindByEmailAsync(request.Email);
                var currentUserName = await _userManager.FindByNameAsync(request.UserName);

                if (currentEmail == null && currentUserName == null)
                {
                    var newUser = new User
                    {
                        UserName = request.UserName,
                        Email = request.Email,
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        PhoneNumber = request.PhoneNumber,
                        NormalizedEmail = string.Empty,
                        NormalizedUserName = request.UserName.ToUpper(),
                    };

                    var result = await _userManager.CreateAsync(newUser, request.PasswordHash);
                    if (!result.Succeeded)
                    {
                        throw new Exception("User creation failed");
                    }

                    var getToken =  _loginService.GenerateTokenCommand(request, cancellationToken);

                    return getToken;

                }

            return new Result
            {
                Data = null,
                Error = new string[] { "" },
                IsSuccess = false,
                StatusCode = HttpStatusCode.InternalServerError,
            };
            
           
            
        }
    }
}
