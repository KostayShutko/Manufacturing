using FluentValidation;
using Manufacturing.Common.Application.Extensions;

namespace ProcessingMachines.Application.Commands.CancelProcessCommand;

public class CancelProcessCommandValidator : AbstractValidator<CancelProcessCommand>
{
    public CancelProcessCommandValidator()
    {
        RuleFor(command => command.ProcessId).IdentityWithMessage();
    }
}