using Manufacturing.Common.Domain.Entities;

namespace Transportations.Domain.Entities;

public class Transportation : Entity
{
    public Transportation(Position from, Position to)
    {
        From = from;
        To = to;
    }

    public static Transportation Create(Position from, Position to, Guid workflowId)
    {
        var transportation = new Transportation(from, to);

        transportation.AssignWorkflow(workflowId);

        return transportation;
    }

    public Position From { get; set; }

    public Position To { get; set; }
}