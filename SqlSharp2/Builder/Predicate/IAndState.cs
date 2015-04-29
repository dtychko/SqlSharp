using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Predicate
{
    public interface IAndState
    {
        IAndNotState Not();
        IAndNotExpressionState Not(string expression);
        IPredicateConjuctionState Exists(QueryBase query);
    }
}