using AplicationLayer.Common;
using AplicationLayer.Interfaces;
using AplicationLayer.Request.Command;
using MediatR;

namespace AplicationLayer.Handler.Command
{
    public class DeleteShopCommandHandler : IRequestHandler<DeleteShopCommandRequest, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteShopCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
       
        public async Task<Result> Handle(DeleteShopCommandRequest request, CancellationToken cancellationToken)
        {
            var shop = await _unitOfWork.ShopRepository.GetById(request.ShopId, cancellationToken);

            if (shop == null)
            {
                return new Result
                {
                    Data = false,
                    Error = new string[] { "" },
                    IsSuccess = false,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };

            }

            _unitOfWork.ShopRepository.Remove(shop);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
           
            return new Result
            {
                Data = true,
                Error = null,
                IsSuccess = true,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
    }
}
