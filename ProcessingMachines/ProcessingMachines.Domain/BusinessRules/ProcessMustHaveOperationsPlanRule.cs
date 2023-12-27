using Manufacturing.Common.Domain.BusinessRules;
using ProcessingMachines.Domain.Entities.ProcessingOperations;

namespace ProcessingMachines.Domain.BusinessRules;

public class ProcessMustHaveOperationsPlanRule : IBusinessRule
{
    private readonly IEnumerable<ProcessingOperation> operationsPlan;

    public ProcessMustHaveOperationsPlanRule(IEnumerable<ProcessingOperation> operationsPlan)
    {
        this.operationsPlan = operationsPlan;
    }

    public bool IsBroken() => operationsPlan == null || !operationsPlan.Any();

    public string Message => "Process must have operations plan";
}
