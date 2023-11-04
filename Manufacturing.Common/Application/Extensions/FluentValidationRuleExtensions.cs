using FluentValidation;

namespace Manufacturing.Common.Application.Extensions
{
    public static class FluentValidationRuleExtensions
    {
        public static IRuleBuilderOptions<T, int> IdentityWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
        {
            return ruleBuilder.NotEmpty().GreaterThan(0).WithMessage("Id is not valid");
        }
    }
}
