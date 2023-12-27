using Manufacturing.Common.Application.Commands;
using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Domain.Entities;
using Manufacturing.Common.Infrastructure.Repository;
using MediatR;
using ProcessingMachines.Domain.Entities;
using ProcessingMachines.Domain.Entities.ProcessingMachines;
using ProcessingMachines.Domain.Entities.ProcessingOperations;

namespace ProcessingMachines.Application.Commands.StartProcessCommand;

public class StartProcessCommandHandler : BaseCommand<Process>, IRequestHandler<StartProcessCommand, ResponseResult>
{
    public StartProcessCommandHandler(IUnitOfWork unitOfWork)
        : base(unitOfWork)
    {
    }

    public async Task<ResponseResult> Handle(StartProcessCommand command, CancellationToken cancellationToken)
    {
        var process = await StartProcessExecution(command.ProcessId, command.ProductCode);
        var product = await ProduceProduct(process);
        await CompleteProcessExecution(process, product);

        return ResponseResult.CreateSuccess();
    }

    private async Task<Process> StartProcessExecution(int processId, ProductCode productCode)
    {
        var process = await FindByIdAsync(processId);

        var processingOperationsPlanner = new ProcessingOperationsPlanner();
        var plan = processingOperationsPlanner.GetProcessingOperationsPlan(productCode);

        process.PlanProduction(productCode, plan);
        process.StartExecution();

        await SaveChangesAsync(process);

        return process;
    }

    private async Task<Product> ProduceProduct(Process process)
    {
        var processingMachinesScheduler = new ProcessingMachinesScheduler();
        var processingMachine = processingMachinesScheduler.GetMachine(process);

        var product = processingMachine.ProduceProduct(process);

        await Task.Delay(3000);

        var savedProduct = await SaveChangesAsync(product);

        return savedProduct;
    }

    private async Task CompleteProcessExecution(Process process, Product product)
    {
        var processToComplete = await FindByIdAsync(process.Id);

        processToComplete.Complete(product);

        await SaveChangesAsync(processToComplete);
    }
}
