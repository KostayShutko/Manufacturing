using Manufacturing.Common.Domain.Entities;
using Manufacturing.Common.Infrastructure.Repository;

namespace Manufacturing.Common.Application.Specifications;

public class GetByWorkflowIdSpecification<TEntity> : BaseSpecification<TEntity>
    where TEntity : Entity
{
    public GetByWorkflowIdSpecification(Guid workflowId)
    {
        SetFilterCondition(entity => entity.WorkflowId == workflowId);
    }
}
