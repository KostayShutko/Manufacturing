using Manufacturing.Common.Domain.BusinessRules;
using MaterialsWarehouse.Domain.Entities;

namespace MaterialsWarehouse.Domain.BusinessRules
{
    public class MaterialMustBeAvailableRule : IBusinessRule
    {
        private readonly MaterialState state;

        public MaterialMustBeAvailableRule(MaterialState state)
        {
            this.state = state;
        }

        public bool IsBroken() => state != MaterialState.Available;

        public string Message => "Material must be in available state";
    }
}
