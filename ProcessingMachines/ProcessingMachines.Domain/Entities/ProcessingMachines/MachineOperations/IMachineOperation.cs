namespace ProcessingMachines.Domain.Entities.ProcessingMachines.MachineOperations;

public interface IMachineOperation
{
    void Execute(Product product);
}
