using AplicationLayer.Request.Command;
using FluentValidation;

namespace AplicationLayer.Validation
{
    public class RegisterUserValidation : AbstractValidator<RegisterUserCommandRequest>
    {
        public RegisterUserValidation()
        {
            RuleFor(u => u.UserName)
                .NotNull()
                .WithMessage("user name can not be null");

            RuleFor(u => u.PasswordHash)
                .NotNull()
                .WithMessage("password can not be null");

            RuleFor(u => u.PhoneNumber)
                .NotNull()
                .Length(11)
                .Matches("^((\\+98|0)9\\d{9})$")
                .WithMessage("phoneNumber can not be null");

            RuleFor(u => u.Email)
                .NotNull()
                .WithMessage("Email can not be null");

        }
    }
}
