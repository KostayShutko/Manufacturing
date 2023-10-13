using MaterialsWarehouse.Domain.Entities;
using MaterialsWarehouse.Infrastructure.Database;

namespace MaterialsWarehouse.Infrastructure.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly MaterialsContext materialsContext;

        public MaterialRepository(MaterialsContext materialsContext)
        {
            this.materialsContext = materialsContext;
        }

        public async Task<Material> AddMaterialAsync(Material material)
        {
            var result = materialsContext.Materials.Add(material);
            await materialsContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
