using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.Repository;
using MediatR;
using ProcessingMachines.Domain.Entities;

namespace ProcessingMachines.Application.Commands.StartProcessCommand;

public class StartProcessCommandHandler : IRequestHandler<StartProcessCommand, ResponseResult>
{
    private readonly IUnitOfWork unitOfWork;

    public StartProcessCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<ResponseResult> Handle(StartProcessCommand command, CancellationToken cancellationToken)
    {
        await StartExecution(command.ProcessId);
        await ExecuteProcess();
        await Complete(command.ProcessId);

        return ResponseResult.CreateSuccess();
    }

    private async Task StartExecution(int processId)
    {
        var process = await unitOfWork.Repository<Process>().FindByIdAsync(processId);

        process.StartExecution();

        unitOfWork.Repository<Process>().Update(process);
        await unitOfWork.SaveChangesAsync();
    }

    private async Task ExecuteProcess()
    {
        await Task.Delay(3000);
    }

    private async Task Complete(int processId)
    {
        var process = await unitOfWork.Repository<Process>().FindByIdAsync(processId);

        process.Complete();

        unitOfWork.Repository<Process>().Update(process);
        await unitOfWork.SaveChangesAsync();
    }
}
