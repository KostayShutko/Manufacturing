using FluentValidation;
using Manufacturing.Common.Application.Extensions;

namespace MaterialsWarehouse.Application.Commands.TransportMaterialCommand
{
    public class TransportMaterialCommandValidator : AbstractValidator<TransportMaterialCommand>
    {
        public TransportMaterialCommandValidator()
        {
            RuleFor(command => command.MaterialId).IdentityWithMessage();
        }
    }
}
