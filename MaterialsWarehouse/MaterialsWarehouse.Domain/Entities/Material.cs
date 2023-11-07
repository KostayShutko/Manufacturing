using Manufacturing.Common.Domain.Entities;
using MaterialsWarehouse.Domain.BusinessRules;

namespace MaterialsWarehouse.Domain.Entities
{
    public class Material : Entity
    {
        public Material() 
        {
            State = MaterialState.Available;
        }

        public MaterialState State { get; set; }

        public static Material Create()
        {
            var material = new Material();

            return material;
        }

        public void Reserve()
        {
            CheckRule(new MaterialMustBeAvailableRule(State));

            State = MaterialState.Reserved;
        }

        public void Transport()
        {
            CheckRule(new MaterialMustBeReservedRule(State));

            State = MaterialState.Transported;
        }

        public void CancelReservation()
        {
            State = MaterialState.Available;
        }
    }
}
