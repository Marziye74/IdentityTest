using AplicationLayer.Common;
using MediatR;

namespace AplicationLayer.Request.Command
{
    public class RegisterUserCommandRequest : IRequest<Result>
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? PhoneNumber { get; set; }

    }
}
