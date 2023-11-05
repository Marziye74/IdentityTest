using AplicationLayer.Request.Command;
using FluentValidation;

namespace AplicationLayer.Validation
{
    public class AddShopValidation : AbstractValidator<AddShopCommandRequest>
    {
        public AddShopValidation() 
        {
            RuleFor(sh => sh.Name)
                .NotNull()
                .WithMessage("name can not be null");

            RuleFor(sh => sh.Code)
                .NotNull()
                .WithMessage("code can not be null");

        }
    }
}
