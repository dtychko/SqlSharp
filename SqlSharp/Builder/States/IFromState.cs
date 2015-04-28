using SqlSharp.Expressions;

namespace SqlSharp.Builder
{
    public interface IFromState : IFinalState
    {
        IFromState From(string table);
        IFromAsState As(string alias);
        IJoinState Join(string table, JoinType joinType);
    }
}