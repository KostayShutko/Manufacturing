using Manufacturing.Common.Domain.BusinessRules;
using MaterialsWarehouse.Domain.Entities;

namespace MaterialsWarehouse.Domain.BusinessRules
{
    public class MaterialMustBeReservedRule : IBusinessRule
    {
        private readonly MaterialState state;

        public MaterialMustBeReservedRule(MaterialState state)
        {
            this.state = state;
        }

        public bool IsBroken() => state != MaterialState.Reserved;

        public string Message => "Material must be in reserved state";
    }
}
