using ProcessingMachines.Domain.Entities.ProcessingMachines.MachineOperations;
using ProcessingMachines.Domain.Entities.ProcessingOperations;

namespace ProcessingMachines.Domain.Entities.ProcessingMachines;

public abstract class BaseProcessingMachine : IProcessingMachine
{
    public abstract Product ProduceProduct(Process process);

    protected Product ProduceProduct(Process process, IEnumerable<IMachineOperation> machineOperations)
    {
        var product = Product.Create(process);

        foreach (var processingOperation in process.OperationsPlan)
        {
            var machineOperation = GetMachineOperation(processingOperation, machineOperations);
            machineOperation.Execute(product);
        }

        return product;
    }

    private IMachineOperation GetMachineOperation(ProcessingOperation processingOperation, IEnumerable<IMachineOperation> machineOperations)
    {
        return machineOperations.First(machineOperation => machineOperation.ProcessingOperation == processingOperation);
    }
}
