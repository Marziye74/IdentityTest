using AplicationLayer.Common;
using AplicationLayer.Interfaces;
using AplicationLayer.Request.Command;
using MediatR;


namespace AplicationLayer.Handler.Command
{
    public class UpdateShopCommandHandler : IRequestHandler<UpdateShopCommandRequest, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateShopCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(UpdateShopCommandRequest request, CancellationToken cancellationToken)
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

            shop.Name = request.Name;
            _unitOfWork.ShopRepository.Update(shop);
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
