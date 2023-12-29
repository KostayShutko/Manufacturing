using FluentValidation;
using Manufacturing.Common.Application.Extensions;

namespace ProductsWarehouse.Application.Commands.PlaceProductCommand;

public class PlaceProductCommandValidator : AbstractValidator<PlaceProductCommand>
{
    public PlaceProductCommandValidator()
    {
        RuleFor(command => command.WorkflowId).IdentityWithMessage();
    }
}
