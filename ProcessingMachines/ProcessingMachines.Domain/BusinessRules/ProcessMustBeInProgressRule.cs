using Manufacturing.Common.Domain.BusinessRules;
using ProcessingMachines.Domain.Entities;

namespace ProcessingMachines.Domain.BusinessRules;

public class ProcessMustBeInProgressRule : IBusinessRule
{
    private readonly ProcessState state;

    public ProcessMustBeInProgressRule(ProcessState state)
    {
        this.state = state;
    }

    public bool IsBroken() => state != ProcessState.InProgress;

    public string Message => "Process must be in progress state";
}
