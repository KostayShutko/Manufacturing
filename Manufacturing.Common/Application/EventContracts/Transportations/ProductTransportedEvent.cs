﻿using Manufacturing.Common.Domain.Entities;

namespace Manufacturing.Common.Application.EventContracts.Transportations;

public class ProductTransportedEvent : BaseEvent
{
    public ProductTransportedEvent(ProductCode productCode, int workflowId)
        : base(workflowId)
    {
        ProductCode = productCode;
    }

    public ProductCode ProductCode { get; set; }
}