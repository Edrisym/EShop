using FluentValidation;

namespace Basket.Api.Basket.StoreBasket;

public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidator()
    {
        RuleFor(x => x.Cart)
            .NotNull()
            .WithMessage("Cart can not be empty");

        RuleFor(x => x.Cart.UserName)
            .NotEmpty()
            .WithMessage("username is required");

    }
}