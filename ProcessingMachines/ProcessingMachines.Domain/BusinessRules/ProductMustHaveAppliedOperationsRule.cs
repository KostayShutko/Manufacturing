using Manufacturing.Common.Domain.BusinessRules;

namespace ProcessingMachines.Domain.BusinessRules;

public class ProductMustHaveAppliedOperationsRule : IBusinessRule
{
    private readonly IEnumerable<string> productAppliedOperations;

    public ProductMustHaveAppliedOperationsRule(IEnumerable<string> productAppliedOperations)
    {
        this.productAppliedOperations = productAppliedOperations;
    }

    public bool IsBroken() => productAppliedOperations == null || !productAppliedOperations.Any();

    public string Message => "Product must have applied operations";
}
