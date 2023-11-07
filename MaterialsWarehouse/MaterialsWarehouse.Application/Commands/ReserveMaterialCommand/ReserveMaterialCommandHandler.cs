using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.Repository;
using MaterialsWarehouse.Application.Specifications;
using MaterialsWarehouse.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MaterialsWarehouse.Application.Commands.ReserveMaterialCommand
{
    public class ReserveMaterialCommandHandler : IRequestHandler<ReserveMaterialCommand, ResponseResult<int>>
    {
        private readonly IUnitOfWork unitOfWork;

        public ReserveMaterialCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<ResponseResult<int>> Handle(ReserveMaterialCommand command, CancellationToken cancellationToken)
        {
            var material = await unitOfWork.Repository<Material>().Find(new MaterialToReserveSpecification()).FirstOrDefaultAsync();

            if (material == null)
            {
                return ResponseResult<int>.CreateFail("No material to reserve");
            }

            material.Reserve();

            unitOfWork.Repository<Material>().Update(material);
            await unitOfWork.SaveChangesAsync();

            return ResponseResult.CreateSuccess(material.Id);
        }
    }
}
