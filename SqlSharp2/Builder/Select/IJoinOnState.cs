using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Select
{
    public interface IJoinOnState : IQueryState
    {
        IFromState From(string table);
        IFromState From(IQuery subquery);
        IJoinState Join(string table, JoinType joinType);
        IJoinState Join(IQuery subquery, JoinType joinType);
        IOrderByState OrderBy(string column);
    }
}