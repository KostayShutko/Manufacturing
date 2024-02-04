using FluentValidation;
using Manufacturing.Common.Application.Extensions;

namespace MaterialsWarehouse.Application.Commands.CancelReservationMaterialCommand
{
    public class CancelMaterialReservationCommandValidator : AbstractValidator<CancelMaterialReservationCommand>
    {
        public CancelMaterialReservationCommandValidator()
        {
            RuleFor(command => command.MaterialId).IdentityWithMessage();
        }
    }
}
