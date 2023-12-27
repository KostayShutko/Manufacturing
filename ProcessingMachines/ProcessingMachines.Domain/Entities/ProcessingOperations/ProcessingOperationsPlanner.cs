using Manufacturing.Common.Domain.Entities;

namespace ProcessingMachines.Domain.Entities.ProcessingOperations;

public class ProcessingOperationsPlanner
{
    public IEnumerable<ProcessingOperation> GetProcessingOperationsPlan(ProductCode productCode)
    {
        return PlanDefinitions.GetValueOrDefault(productCode) ?? throw new ArgumentOutOfRangeException(nameof(productCode));
    }

    private static readonly Dictionary<ProductCode, IEnumerable<ProcessingOperation>> PlanDefinitions = new Dictionary<ProductCode, IEnumerable<ProcessingOperation>>
    {
        { 
            ProductCode.ProductCode1,
            new List<ProcessingOperation> 
            {
                ProcessingOperation.ProcessingOperation1,
                ProcessingOperation.ProcessingOperation3,
                ProcessingOperation.ProcessingOperation4
            }
        },
        {
            ProductCode.ProductCode2,
            new List<ProcessingOperation>
            {
                ProcessingOperation.ProcessingOperation1,
                ProcessingOperation.ProcessingOperation3,
                ProcessingOperation.ProcessingOperation4
            }
        },
        {
            ProductCode.ProductCode3,
            new List<ProcessingOperation>
            {
                ProcessingOperation.ProcessingOperation1,
                ProcessingOperation.ProcessingOperation3,
                ProcessingOperation.ProcessingOperation5
            }
        },
        {
            ProductCode.ProductCode4,
            new List<ProcessingOperation>
            {
                ProcessingOperation.ProcessingOperation2,
                ProcessingOperation.ProcessingOperation3,
                ProcessingOperation.ProcessingOperation4
            }
        },
        {
            ProductCode.ProductCode5,
            new List<ProcessingOperation>
            {
                ProcessingOperation.ProcessingOperation2,
                ProcessingOperation.ProcessingOperation3,
                ProcessingOperation.ProcessingOperation5
            }
        }
    };
}
