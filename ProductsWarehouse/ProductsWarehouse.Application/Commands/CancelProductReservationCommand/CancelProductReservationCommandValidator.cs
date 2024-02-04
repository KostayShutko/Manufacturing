using FluentValidation;
using Manufacturing.Common.Application.Extensions;

namespace ProductsWarehouse.Application.Commands.CancelProductReservationCommand;

public class CancelProductReservationCommandValidator : AbstractValidator<CancelProductReservationCommand>
{
    public CancelProductReservationCommandValidator()
    {
        RuleFor(command => command.ProductId).IdentityWithMessage();
    }
}
