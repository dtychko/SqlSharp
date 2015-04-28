using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Select
{
    public interface IOrderByState : ISelectStatementBuilder
    {
        IOrderByState OrderBy(string column);
        IOrderByInDirectionState InDirection(OrderDirection direction);
    }
}