using Manufacturing.Common.Domain.BusinessRules;
using ProcessingMachines.Domain.Entities;

namespace ProcessingMachines.Domain.BusinessRules;

public class ProcessMustBeReadyToExecuteRule : IBusinessRule
{
    private readonly ProcessState state;

    public ProcessMustBeReadyToExecuteRule(ProcessState state)
    {
        this.state = state;
    }

    public bool IsBroken() => state != ProcessState.Ready;

    public string Message => "Process must be in ready state";
}
