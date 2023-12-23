using FluentValidation;
using Manufacturing.Common.Application.Extensions;

namespace ProcessingMachines.Application.Commands.StartProcessCommand;

public class StartProcessCommandValidator : AbstractValidator<StartProcessCommand>
{
    public StartProcessCommandValidator()
    {
        RuleFor(command => command.ProcessId).IdentityWithMessage();
    }
}