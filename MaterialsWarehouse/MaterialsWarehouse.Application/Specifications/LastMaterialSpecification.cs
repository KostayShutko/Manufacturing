using MaterialsWarehouse.Domain.Entities;
using MaterialsWarehouse.Infrastructure.Repositories;

namespace MaterialsWarehouse.Application.Specifications
{
    public class LastMaterialSpecification : BaseSpecification<Material>
    {
        public LastMaterialSpecification() 
        {
            SetFilterCondition(material => material.Id > 100);
        }
    }
}
