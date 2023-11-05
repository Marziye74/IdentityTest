using AplicationLayer.Request.Command;
using FluentValidation;

namespace AplicationLayer.Validation
{
    public class UpdateShopValidation : AbstractValidator<UpdateShopCommandRequest>
    {
        public UpdateShopValidation() 
        {
            RuleFor(sh => sh.ShopId)
                .NotEqual(0)
                .WithMessage("shopId can not be null");

            RuleFor(sh => sh.Name)
                .NotNull()
                .WithMessage("name can not be null");
        }
    }
}
