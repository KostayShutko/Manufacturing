﻿using Manufacturing.Common.Common.Extensions;
using Manufacturing.Common.Domain.BusinessRules;
using Manufacturing.Common.Domain.Exceptions;

namespace Manufacturing.Common.Domain.Entities;

public abstract class Entity
{
    public int Id { get; set; }

    public Guid WorkflowId { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime UpdatedOn { get; set; }

    protected static void CheckRule(IBusinessRule rule)
    {
        if (rule.IsBroken())
        {
            throw new BusinessRuleValidationException(rule);
        }
    }

    public void AssignWorkflow(Guid workflowId)
    {
        WorkflowId = workflowId;
    }

    public bool IsNew() => Id.IsNew();
}
