using Manufacturing.Common.Domain.BusinessRules;
using Manufacturing.Common.Domain.Entities;

namespace ProductsWarehouse.Domain.BusinessRules;

public class ProductMustHaveProductCodeRule : IBusinessRule
{
    private readonly ProductCode? productCode;

    public ProductMustHaveProductCodeRule(ProductCode? code)
    {
        productCode = code;
    }

    public bool IsBroken() => !productCode.HasValue;

    public string Message => "Product must have product code";
}
