using MaterialsWarehouse.Domain.Entities;

namespace MaterialsWarehouse.Infrastructure.Repositories
{
    public interface IMaterialRepository
    {
        Task<Material> AddMaterialAsync(Material material);
    }
}
