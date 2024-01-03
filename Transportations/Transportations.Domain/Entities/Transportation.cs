using Manufacturing.Common.Domain.Entities;

namespace Transportations.Domain.Entities;

public class Transportation : Entity
{
    public Transportation(Position from, Position to, int workflowId)
    {
        From = from;
        To = to;
        WorkflowId = workflowId;
    }

    public static Transportation Create(Position from, Position to, int workflowId)
    {
        var transportation = new Transportation(from, to, workflowId);

        return transportation;
    }

    public Position From { get; set; }

    public Position To { get; set; }
}