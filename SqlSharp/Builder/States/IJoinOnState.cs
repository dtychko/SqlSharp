using SqlSharp.Expressions;

namespace SqlSharp.Builder
{
    public interface IJoinOnState : IFinalState
    {
        IFromState From(string table);
        IJoinState Join(string table, JoinType joinType);
    }
}