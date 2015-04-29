using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Predicate
{
    public interface IOrState
    {
        IOrNotState Not();
        IOrNotExpressionState Not(string expression);
        IPredicateDisjunctionState Exists(QueryBase query);
    }
}