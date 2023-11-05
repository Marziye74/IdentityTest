using AplicationLayer.Common;
using AplicationLayer.Request.Command;
using AplicationLayer.Request.Query;

namespace AplicationLayer.Interfaces
{
    public interface ILoginService
    {
        Result GenerateToken(GenerateToken user, CancellationToken cancellationToken);
        
    }
}
