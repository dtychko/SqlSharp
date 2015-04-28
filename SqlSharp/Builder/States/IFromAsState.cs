using SqlSharp.Expressions;

namespace SqlSharp.Builder
{
    public interface IFromAsState : IFinalState
    {
        IFromState From(string table);
        IJoinState Join(string table, JoinType joinType);
    }
}