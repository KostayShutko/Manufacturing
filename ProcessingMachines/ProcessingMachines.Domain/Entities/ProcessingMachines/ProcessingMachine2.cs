using ProcessingMachines.Domain.Entities.ProcessingMachines.MachineOperations;

namespace ProcessingMachines.Domain.Entities.ProcessingMachines; 

public class ProcessingMachine2 : BaseProcessingMachine
{
    public override Product ProduceProduct(Process process)
    {
        var product = base.ProduceProduct(process, MachineOperations);
        return product;
    }

    private static readonly IEnumerable<IMachineOperation> MachineOperations = new List<IMachineOperation>
    {
        new MachineOperation21(),
        new MachineOperation22(),
        new MachineOperation23(),
        new MachineOperation24(),
        new MachineOperation25()
    };
}
