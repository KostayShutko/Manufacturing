using Manufacturing.Common.Domain.Entities;

namespace ProcessingMachines.Domain.Entities.ProcessingMachines;

public class ProcessingMachinesScheduler
{
    public BaseProcessingMachine GetMachine(Process process)
    {
        switch (process.ProductCode)
        {
            case ProductCode.ProductCode1:
            case ProductCode.ProductCode2:
            case ProductCode.ProductCode3:
                return new ProcessingMachine1();
            case ProductCode.ProductCode4:
            case ProductCode.ProductCode5:
                return new ProcessingMachine2();
            default:
                throw new ArgumentOutOfRangeException(nameof(ProductCode));
        }
    }
}
