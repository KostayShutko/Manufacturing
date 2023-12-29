using Manufacturing.Common.Domain.BusinessRules;
using ProductsWarehouse.Domain.Entities;

namespace ProductsWarehouse.Domain.BusinessRules;

public class ProductMustBePlacedRule : IBusinessRule
{
    private readonly ProductState state;

    public ProductMustBePlacedRule(ProductState state)
    {
        this.state = state;
    }

    public bool IsBroken() => state != ProductState.Placed;

    public string Message => "Product must be in placed state";
}
