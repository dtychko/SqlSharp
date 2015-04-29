using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Select
{
    public interface IJoinOnState : IQueryState
    {
        IFromState From(string table);
        IFromState From(QueryBase subquery);
        IJoinState Join(string table, JoinType joinType);
        IJoinState Join(QueryBase subquery, JoinType joinType);
        IOrderByState OrderBy(string column);
    }
}