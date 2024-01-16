using Manufacturing.Common.Domain.Entities;

namespace ProcessingMachines.Domain.Entities;

public class Product : Entity
{
    public Product() { }

    public ProductCode ProductCode { get; set; }

    public int MaterialId { get; set; }

    public int ProcessId { get; set; }

    public Process Process { get; set; }

    public ICollection<string> AppliedOperations { get; set; }

    public Product(ProductCode productCode, int materialId, Process process)
    {
        AppliedOperations = new List<string>();
        ProductCode = productCode;
        Process = process;
        MaterialId = materialId;
    }

    public static Product Create(Process process)
    {
        var product = new Product(process.ProductCode, process.MaterialId, process);

        product.AssignWorkflow(process.WorkflowId);

        return product;
    }

    public void ApplyOperation(string operation)
    {
        AppliedOperations.Add(operation);
    }
}
