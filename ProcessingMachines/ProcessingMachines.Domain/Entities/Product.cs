using Manufacturing.Common.Domain.Entities;

namespace ProcessingMachines.Domain.Entities;

public class Product : Entity
{
    public ProductCode ProductCode { get; set; }

    public ICollection<string> AppliedOperations { get; set; }

    public Product(ProductCode productCode)
    {
        AppliedOperations = new List<string>();
        ProductCode = productCode;
    }

    public static Product Create(ProductCode productCode)
    {
        var product = new Product(productCode);

        return product;
    }

    public void ApplyOperation(string operation)
    {
        AppliedOperations.Add(operation);
    }
}
