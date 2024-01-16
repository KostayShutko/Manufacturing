using Manufacturing.Common.Application.Commands;
using Manufacturing.Common.Application.EventContracts.Processes;
using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.EventBus;
using Manufacturing.Common.Infrastructure.Repository;
using MediatR;
using ProcessingMachines.Domain.Entities;

namespace ProcessingMachines.Application.Commands.CreateProcessCommand;

public class CreateProcessCommandHandler : BaseCommand<Process>, IRequestHandler<CreateProcessCommand, ResponseResult<int>>
{
    private readonly IEventPublisher eventPublisher;

    public CreateProcessCommandHandler(IUnitOfWork unitOfWork, IEventPublisher eventPublisher)
        : base(unitOfWork)
    {
        this.eventPublisher = eventPublisher;
    }

    public async Task<ResponseResult<int>> Handle(CreateProcessCommand command, CancellationToken cancellationToken)
    {
        var process = Process.Create(command.MaterialId, command.WorkflowId);

        var addedProcess = await SaveChangesAsync(process);

        await eventPublisher.Publish(new ProcessCreatedEvent(addedProcess.Id, process.WorkflowId));

        return ResponseResult.CreateSuccess(addedProcess.Id);
    }
}
