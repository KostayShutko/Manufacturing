using Manufacturing.Common.Application.ResponseResults;
using MediatR;

namespace ProcessingMachines.Application.Commands.CreateProcessCommand;

public class CreateProcessCommand : IRequest<ResponseResult<int>>
{
    public CreateProcessCommand(int materialId)
    {
        MaterialId = materialId;
    }

    public int MaterialId { get; }
}
