using Manufacturing.Common.Domain.BusinessRules;
using ProductsWarehouse.Domain.Entities;

namespace ProductsWarehouse.Domain.BusinessRules;

public class ProductMustBeReservedRule : IBusinessRule
{
    private readonly ProductState state;

    public ProductMustBeReservedRule(ProductState state)
    {
        this.state = state;
    }

    public bool IsBroken() => state != ProductState.Reserved;

    public string Message => "Product must be in reserved state";
}
