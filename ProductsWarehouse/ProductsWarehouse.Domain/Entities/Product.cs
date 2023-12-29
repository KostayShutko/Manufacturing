using Manufacturing.Common.Domain.Entities;
using ProductsWarehouse.Domain.BusinessRules;

namespace ProductsWarehouse.Domain.Entities;

public class Product : Entity
{
    public Product(int workflowId)
    {
        State = ProductState.Initial;
        WorkflowId = workflowId;
    }

    public ProductState State { get; set; }

    public ProductCode? ProductCode { get; set; }

    public DateTime? PlacedOn { get; set; }

    public DateTime? ShippedOn { get; set; }

    public static Product Create(int workflowId)
    {
        var product = new Product(workflowId);

        return product;
    }

    public void SetProductCode(ProductCode productCode)
    {
        ProductCode = productCode;
    }

    public void Reserve()
    {
        State = ProductState.Reserved;
    }

    public void Place()
    {
        CheckRule(new ProductMustBeReservedRule(State));
        CheckRule(new ProductMustHaveProductCodeRule(ProductCode));

        State = ProductState.Placed;
        PlacedOn = DateTime.Now;
    }

    public void Ship()
    {
        CheckRule(new ProductMustBePlacedRule(State));

        State = ProductState.Shipped;
        ShippedOn = DateTime.Now;
    }
}