using Manufacturing.Common.Domain.BusinessRules;
using Manufacturing.Common.Domain.Exceptions;

namespace Manufacturing.Common.Domain
{
    public abstract class Entity
    {
        public int Id { get; set; }

        protected static void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken())
            {
                throw new BusinessRuleValidationException(rule);
            }
        }
    }
}
