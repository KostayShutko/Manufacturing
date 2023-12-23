using Manufacturing.Common.Domain.Entities;
using ProcessingMachines.Domain.BusinessRules;

namespace ProcessingMachines.Domain.Entities;

public class Process : Entity
{
    public Process() { }

    public Process(int materialId)
    {
        State = ProcessState.Ready;
        MaterialId = materialId;
    }

    public ProcessState State { get; set; }

    public int MaterialId { get; }

    public DateTime? StartedOn { get; set; }

    public DateTime? CompletedOn { get; set; }

    public static Process Create(int materialId)
    {
        var process = new Process(materialId);

        return process;
    }

    public void StartExecution()
    {
        CheckRule(new ProcessMustBeReadyToExecuteRule(State));

        State = ProcessState.InProgress;
        StartedOn = DateTime.UtcNow;
    }

    public void Complete()
    {
        CheckRule(new ProcessMustBeInProgressRule(State));

        State = ProcessState.Completed;
        CompletedOn = DateTime.UtcNow;
    }
}
