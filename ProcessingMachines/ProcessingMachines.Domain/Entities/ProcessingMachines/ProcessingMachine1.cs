using ProcessingMachines.Domain.Entities.ProcessingMachines.MachineOperations;

namespace ProcessingMachines.Domain.Entities.ProcessingMachines;

public class ProcessingMachine1 : BaseProcessingMachine
{
    public override Product ProduceProduct(Process process)
    {
        var product = base.ProduceProduct(process, MachineOperations);
        return product;
    }

    private static readonly IEnumerable<IMachineOperation> MachineOperations = new List<IMachineOperation>
    {
        new MachineOperation11(),
        new MachineOperation12(),
        new MachineOperation13(),
        new MachineOperation14(),
        new MachineOperation15()
    };
}
