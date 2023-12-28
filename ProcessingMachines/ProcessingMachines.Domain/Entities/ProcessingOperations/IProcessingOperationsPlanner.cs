using Manufacturing.Common.Domain.Entities;

namespace ProcessingMachines.Domain.Entities.ProcessingOperations;

public interface IProcessingOperationsPlanner
{
    IEnumerable<ProcessingOperation> GetProcessingOperationsPlan(ProductCode productCode);
}
