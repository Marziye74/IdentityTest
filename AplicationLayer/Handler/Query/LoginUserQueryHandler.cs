using AplicationLayer.Common;
using AplicationLayer.Interfaces;
using AplicationLayer.Request.Query;
using DomainLayer.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AplicationLayer.Handler.Query
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQueryRequest, Result>
    {
        private UserManager<User> _userManager;
        private readonly ILoginService _loginService;
        public LoginUserQueryHandler(UserManager<User> userManager, ILoginService loginService)
        {
            _userManager = userManager;
            _loginService = loginService;
        }


        public async Task<Result> Handle(LoginUserQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                return new Result
                {
                    Data = null,
                    Error = new string[] { "کاربر مورد نظر در سیستم وجود ندارد" },
                    IsSuccess = false,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                };
            }

            return _loginService.GenerateToken(new GenerateToken
            {
                Name = request.UserName,
                Password = request.Password,
                UserId = user.Id,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber

            }, cancellationToken);
        }
    }
}
