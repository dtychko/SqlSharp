using SqlSharp2.Tree;

namespace SqlSharp2.Builder
{
    public interface IOrderByState : ISelectStatementState
    {
        IOrderByState OrderBy(string column);
        IOrderByInDirectionState InDirection(OrderDirection direction);
    }
}