using FluentValidation;
using Manufacturing.Common.Application.Extensions;

namespace MaterialsWarehouse.Application.Commands.CancelReservationMaterialCommand
{
    public class CancelReservationMaterialCommandValidator : AbstractValidator<CancelReservationMaterialCommand>
    {
        public CancelReservationMaterialCommandValidator()
        {
            RuleFor(command => command.MaterialId).IdentityWithMessage();
        }
    }
}
