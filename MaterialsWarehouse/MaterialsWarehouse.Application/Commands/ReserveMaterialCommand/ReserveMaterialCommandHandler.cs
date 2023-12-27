using Manufacturing.Common.Application.Commands;
using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.Repository;
using MaterialsWarehouse.Application.Specifications;
using MaterialsWarehouse.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MaterialsWarehouse.Application.Commands.ReserveMaterialCommand
{
    public class ReserveMaterialCommandHandler : BaseCommand<Material>, IRequestHandler<ReserveMaterialCommand, ResponseResult<int>>
    {
        public ReserveMaterialCommandHandler(IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {
        }

        public async Task<ResponseResult<int>> Handle(ReserveMaterialCommand command, CancellationToken cancellationToken)
        {
            var material = await FindBySpecification(new MaterialToReserveSpecification()).FirstOrDefaultAsync();

            if (material == null)
            {
                return ResponseResult<int>.CreateFail("No material to reserve");
            }

            material.Reserve();

            await SaveChangesAsync(material);

            return ResponseResult.CreateSuccess(material.Id);
        }
    }
}
