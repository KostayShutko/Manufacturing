namespace ProcessingMachines.Domain.Entities.ProcessingMachines.MachineOperations;

public abstract class BaseMachineOperation : IMachineOperation
{
    public void Execute(Product product)
    {
        product.ApplyOperation(GetType().Name);
    }
}
