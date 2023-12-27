using Manufacturing.Common.Application.Commands;
using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.Repository;
using MediatR;
using ProcessingMachines.Domain.Entities;

namespace ProcessingMachines.Application.Commands.StartProcessCommand;

public class StartProcessCommandHandler : BaseCommand<Process>, IRequestHandler<StartProcessCommand, ResponseResult>
{
    public StartProcessCommandHandler(IUnitOfWork unitOfWork)
        : base(unitOfWork)
    {
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
        var process = await FindByIdAsync(processId);

        process.StartExecution();

        await SaveChangesAsync(process);
    }

    private async Task ExecuteProcess()
    {
        await Task.Delay(3000);
    }

    private async Task Complete(int processId)
    {
        var process = await FindByIdAsync(processId);

        process.Complete();

        await SaveChangesAsync(process);
    }
}
