using AplicationLayer.Common;
using DomainLayer.Entities;
using MediatR;

namespace AplicationLayer.Request.Command
{
    public class AddShopCommandRequest : IRequest<Result>
    {
        public string Name { get; set; }
        public int Code { get; set; }
    }
}
