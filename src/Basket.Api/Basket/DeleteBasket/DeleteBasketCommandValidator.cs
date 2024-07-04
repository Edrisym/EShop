using FluentValidation;

namespace Basket.Api.Basket.DeleteBasket;

public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
{
    public DeleteBasketCommandValidator()
    {
        RuleFor(c => c.UserName)
            .NotNull()
            .WithMessage("Username can not be empty");
    }   
}