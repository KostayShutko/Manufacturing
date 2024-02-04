using Manufacturing.Common.Application.Commands;
using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.Repository;
using MediatR;
using ProcessingMachines.Domain.Entities;

namespace ProcessingMachines.Application.Commands.CancelProcessCommand;

public  class CancelProcessCommandHandler : BaseCommand<Process>, IRequestHandler<CancelProcessCommand, ResponseResult>
{
    public CancelProcessCommandHandler(IUnitOfWork unitOfWork)
            : base(unitOfWork)
    {
    }

    public async Task<ResponseResult> Handle(CancelProcessCommand command, CancellationToken cancellationToken)
    {
        var process = await FindByIdAsync(command.ProcessId);

        process.Cancel();

        await SaveChangesAsync(process);

        return ResponseResult.CreateSuccess();
    }
}
