using AplicationLayer.Common;
using MediatR;

namespace AplicationLayer.Request.Command
{
    public class DeleteShopCommandRequest : IRequest<Result>
    {
        public int ShopId { get; set; }
    }
}
