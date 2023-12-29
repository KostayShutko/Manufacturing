using FluentValidation;
using Manufacturing.Common.Application.Extensions;

namespace ProductsWarehouse.Application.Commands.ReserveProductCommand;

public class ReserveProductCommandValidator : AbstractValidator<ReserveProductCommand>
{
    public ReserveProductCommandValidator()
    {
        RuleFor(command => command.WorkflowId).IdentityWithMessage();
    }
}