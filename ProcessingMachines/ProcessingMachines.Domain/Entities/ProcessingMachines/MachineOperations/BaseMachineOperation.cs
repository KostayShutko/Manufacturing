using ProcessingMachines.Domain.Entities.ProcessingOperations;

namespace ProcessingMachines.Domain.Entities.ProcessingMachines.MachineOperations;

public abstract class BaseMachineOperation : IMachineOperation
{
    public abstract ProcessingOperation ProcessingOperation { get; }

    public void Execute(Product product)
    {
        product.ApplyOperation(GetType().Name);
    }
}
