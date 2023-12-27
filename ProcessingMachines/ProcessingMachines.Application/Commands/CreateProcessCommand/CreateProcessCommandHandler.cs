using Manufacturing.Common.Application.Commands;
using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.Repository;
using MediatR;
using ProcessingMachines.Domain.Entities;

namespace ProcessingMachines.Application.Commands.CreateProcessCommand;

public class CreateProcessCommandHandler : BaseCommand<Process>, IRequestHandler<CreateProcessCommand, ResponseResult<int>>
{
    public CreateProcessCommandHandler(IUnitOfWork unitOfWork)
        : base(unitOfWork)
    {
    }

    public async Task<ResponseResult<int>> Handle(CreateProcessCommand command, CancellationToken cancellationToken)
    {
        var process = Process.Create(command.MaterialId);

        var addedProcess = await SaveChangesAsync(process);

        return ResponseResult.CreateSuccess(addedProcess.Id);
    }
}
