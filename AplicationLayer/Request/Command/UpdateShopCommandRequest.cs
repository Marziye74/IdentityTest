using AplicationLayer.Common;
using MediatR;

namespace AplicationLayer.Request.Command
{
    public class UpdateShopCommandRequest : IRequest<Result>
    {
        public int ShopId { get; set; }
        public string Name { get; set; }         
    }
}
