using AplicationLayer.Common;
using MediatR;

namespace AplicationLayer.Request.Query
{
    public class LoginUserQueryRequest : IRequest<Result>
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }

    }
}
