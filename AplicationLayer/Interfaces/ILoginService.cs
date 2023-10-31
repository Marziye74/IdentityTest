using AplicationLayer.Common;
using AplicationLayer.Request.Command;
using AplicationLayer.Request.Query;

namespace AplicationLayer.Interfaces
{
    public interface ILoginService
    {
        Result GenerateTokenCommand(RegisterUserCommandRequest user, CancellationToken cancellationToken);
        Result GenerateTokenQuery(LoginUserQueryRequest user, CancellationToken cancellationToken);
    }
}
