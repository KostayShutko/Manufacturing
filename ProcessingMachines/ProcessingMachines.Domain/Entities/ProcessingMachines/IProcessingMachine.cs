namespace ProcessingMachines.Domain.Entities.ProcessingMachines;

public interface IProcessingMachine
{
    Product ProduceProduct(Process process);
}
