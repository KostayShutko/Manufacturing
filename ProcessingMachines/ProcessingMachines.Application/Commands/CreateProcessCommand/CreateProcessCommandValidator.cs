using FluentValidation;
using Manufacturing.Common.Application.Extensions;

namespace ProcessingMachines.Application.Commands.CreateProcessCommand;

public class CreateProcessCommandValidator : AbstractValidator<CreateProcessCommand>
{
    public CreateProcessCommandValidator()
    {
        RuleFor(command => command.MaterialId).IdentityWithMessage();
    }
}
