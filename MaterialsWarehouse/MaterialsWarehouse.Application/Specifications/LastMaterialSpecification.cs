using Manufacturing.Common.Repository;
using MaterialsWarehouse.Domain.Entities;

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
