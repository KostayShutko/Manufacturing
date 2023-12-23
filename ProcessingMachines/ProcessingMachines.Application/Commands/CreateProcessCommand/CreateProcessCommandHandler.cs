using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.Repository;
using MediatR;
using ProcessingMachines.Domain.Entities;

namespace ProcessingMachines.Application.Commands.CreateProcessCommand;

public class CreateProcessCommandHandler : IRequestHandler<CreateProcessCommand, ResponseResult<int>>
{
    private readonly IUnitOfWork unitOfWork;

    public CreateProcessCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<ResponseResult<int>> Handle(CreateProcessCommand command, CancellationToken cancellationToken)
    {
        var process = Process.Create(command.MaterialId);

        var addedProcess = await unitOfWork.Repository<Process>().AddAsync(process);
        await unitOfWork.SaveChangesAsync();

        return ResponseResult.CreateSuccess(addedProcess.Id);
    }
}
