using FluentValidation;

namespace Ordering.Application.Features.Orders.Commands.CheckoutOrder
{
    public class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
    {
        public CheckoutOrderCommandValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("{UserName} is required.")
                .NotEmpty()
                .MaximumLength(50).WithMessage("{UserName} must not exceed 50 characters.");

            RuleFor(x => x.Addres.EmailAddress)
                .NotNull()
                .NotEmpty().WithMessage("{EmailAddress} is required");

            RuleFor(x => x.TotalPrice)
                .NotNull()
                .NotEmpty().WithMessage("{TotalPrice} is required")
                .GreaterThan(0).WithMessage("{TotalPrice} should be greater than zero");
        }
    }
}
