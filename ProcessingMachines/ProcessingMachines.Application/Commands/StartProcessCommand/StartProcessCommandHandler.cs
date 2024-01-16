using Manufacturing.Common.Application.Commands;
using Manufacturing.Common.Application.EventContracts.Processes;
using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Domain.Entities;
using Manufacturing.Common.Infrastructure.EventBus;
using Manufacturing.Common.Infrastructure.Repository;
using MediatR;
using ProcessingMachines.Domain.Entities;
using ProcessingMachines.Domain.Entities.ProcessingMachines;
using ProcessingMachines.Domain.Entities.ProcessingOperations;

namespace ProcessingMachines.Application.Commands.StartProcessCommand;

public class StartProcessCommandHandler : BaseCommand<Process>, IRequestHandler<StartProcessCommand, ResponseResult>
{
    private readonly IEventPublisher eventPublisher;
    private readonly IProcessingOperationsPlanner processingOperationsPlanner;
    private readonly IProcessingMachinesScheduler processingMachinesScheduler;

    public StartProcessCommandHandler(
        IUnitOfWork unitOfWork,
        IEventPublisher eventPublisher,
        IProcessingOperationsPlanner processingOperationsPlanner, 
        IProcessingMachinesScheduler processingMachinesScheduler)
        : base(unitOfWork)
    {
        this.eventPublisher = eventPublisher;
        this.processingOperationsPlanner = processingOperationsPlanner;
        this.processingMachinesScheduler = processingMachinesScheduler;
    }

    public async Task<ResponseResult> Handle(StartProcessCommand command, CancellationToken cancellationToken)
    {
        var process = await StartProcessExecution(command.ProcessId, command.ProductCode);
        var product = await ProduceProduct(process);
        await CompleteProcessExecution(process);

        await PublishProductProducedEvent(product);

        return ResponseResult.CreateSuccess();
    }

    private async Task<Process> StartProcessExecution(int processId, ProductCode productCode)
    {
        var plan = processingOperationsPlanner.GetProcessingOperationsPlan(productCode);
        var process = await FindByIdAsync(processId);

        process.PlanProduction(productCode, plan);
        process.StartExecution();

        await SaveChangesAsync(process);

        return process;
    }

    private async Task<Product> ProduceProduct(Process process)
    {
        var processingMachine = processingMachinesScheduler.GetMachine(process);

        var product = processingMachine.ProduceProduct(process);

        await Task.Delay(3000);

        var savedProduct = await SaveChangesAsync(product);

        return savedProduct;
    }

    private async Task CompleteProcessExecution(Process process)
    {
        var processToComplete = await FindByIdAsync(process.Id);

        processToComplete.Complete();

        await SaveChangesAsync(processToComplete);
    }

    private async Task PublishProductProducedEvent(Product product)
    {
        var productProducedEvent = new ProductProducedEvent(product.ProductCode, product.WorkflowId);

        await eventPublisher.Publish(productProducedEvent);
    }
}
