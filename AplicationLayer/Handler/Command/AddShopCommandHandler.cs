using AplicationLayer.Common;
using AplicationLayer.Interfaces;
using AplicationLayer.Request.Command;
using DomainLayer.Entities;
using MediatR;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace AplicationLayer.Handler.Command
{
    public class AddShopCommandHandler : IRequestHandler<AddShopCommandRequest, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AddShopCommandHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Result> Handle(AddShopCommandRequest request, CancellationToken cancellationToken)
        {
            
            var existingShop = await _unitOfWork.ShopRepository.GetByName(request.Name, cancellationToken);

            if (existingShop != null)
            {
                throw new Exception("فروشگاه در سیستم ثبت شده است");
            }

            var user = _httpContextAccessor.HttpContext.User;
            string userIdString = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!int.TryParse(userIdString, out int userId))
            {

                throw new Exception("Invalid UserId format");
            }

            var newShop = new Shop
            {
                Name = request.Name,
                Code = request.Code,
                ChangeDate = DateTime.UtcNow,
                CreationDate = DateTime.UtcNow,
                UserId = userId
            };

           await _unitOfWork.ShopRepository.AddAsync(newShop);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new Result
            {
                Data = request,
                Error = null,
                IsSuccess = true,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
    }
}
