namespace ProcessingMachines.Domain.Entities.ProcessingMachines;

public interface IProcessingMachinesScheduler
{
    IProcessingMachine GetMachine(Process process);
}
