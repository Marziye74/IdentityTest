using AplicationLayer.Request.Query;
using FluentValidation;

namespace AplicationLayer.Validation
{
    public class LoginUserQueryValidation : AbstractValidator<LoginUserQueryRequest>
    {
        public LoginUserQueryValidation() 
        {
            RuleFor(u => u.UserName)
                .NotNull()
                .WithMessage("user name can not be null");

            RuleFor(u => u.Password)
                .NotNull()
                .WithMessage("password can not be null");

        }
    }
}
