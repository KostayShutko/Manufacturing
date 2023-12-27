using ProcessingMachines.Domain.Entities.ProcessingMachines.MachineOperations;

namespace ProcessingMachines.Domain.Entities.ProcessingMachines;

public abstract class BaseProcessingMachine : IProcessingMachine
{
    public abstract Product ProduceProduct(Process process);

    protected Product ProduceProduct(Process process, IEnumerable<IMachineOperation> operations)
    {
        var product = Product.Create(process.ProductCode);

        foreach (var operation in operations)
        {
            operation.Execute(product);
        }

        return product;
    }
}
