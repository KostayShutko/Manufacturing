using Manufacturing.Common.Infrastructure.Repository;
using MaterialsWarehouse.Domain.Entities;

namespace MaterialsWarehouse.Application.Specifications;

public class MaterialToReserveSpecification : BaseSpecification<Material>
{
    public MaterialToReserveSpecification()
    {
        SetFilterCondition(material => material.State == MaterialState.Available);
        ApplyOrderBy(material => material.Id);
    }
}
