using AplicationLayer.Request.Command;
using FluentValidation;

namespace AplicationLayer.Validation
{
    public class DeleteShopValidation : AbstractValidator<DeleteShopCommandRequest>
    {
        public DeleteShopValidation() 
        {
            RuleFor(sh => sh.ShopId)
                .NotEqual(0)
                .WithMessage("shopId can not be null");
        }
    }
}
