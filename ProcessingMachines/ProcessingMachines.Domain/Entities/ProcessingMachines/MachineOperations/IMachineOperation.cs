using ProcessingMachines.Domain.Entities.ProcessingOperations;

namespace ProcessingMachines.Domain.Entities.ProcessingMachines.MachineOperations;

public interface IMachineOperation
{
    ProcessingOperation ProcessingOperation { get; }

    void Execute(Product product);
}
