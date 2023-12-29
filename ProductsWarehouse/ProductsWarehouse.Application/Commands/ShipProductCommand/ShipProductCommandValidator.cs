using FluentValidation;
using Manufacturing.Common.Application.Extensions;

namespace ProductsWarehouse.Application.Commands.ShipProductCommand;

public class ShipProductCommandValidator : AbstractValidator<ShipProductCommand>
{
    public ShipProductCommandValidator()
    {
        RuleFor(command => command.ProductId).IdentityWithMessage();
    }
}
