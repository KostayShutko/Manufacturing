﻿namespace Manufacturing.Common.Application.EventContracts.Materials
{
    public class ReserveMaterialCommandEvent : BaseEvent
    {
        public ReserveMaterialCommandEvent(int workflowId) : base(workflowId)
        {
        }
    }
}
