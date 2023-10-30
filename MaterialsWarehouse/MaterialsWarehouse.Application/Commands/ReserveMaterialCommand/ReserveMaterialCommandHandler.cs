using Manufacturing.Common.Repository;
using MaterialsWarehouse.Application.Specifications;
using MaterialsWarehouse.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MaterialsWarehouse.Application.Commands.ReserveMaterialCommand
{
    public class ReserveMaterialCommandHandler : IRequestHandler<ReserveMaterialCommand, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public ReserveMaterialCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(ReserveMaterialCommand command, CancellationToken cancellationToken)
        {
            var material = await unitOfWork.Repository<Material>().Find(new MaterialToReserveSpecification()).FirstAsync();

            material.Reserve();

            unitOfWork.Repository<Material>().Update(material);
            await unitOfWork.SaveChangesAsync();

            return material.Id;
        }
    }
}
