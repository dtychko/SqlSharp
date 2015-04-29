namespace SqlSharp2.Builder.Predicate
{
    public interface ISinglePredicateState : IPredicateBuilder
    {
        IAndState And();
        IAndExpressionState And(string expression);
        IPredicateConjuctionState And(Tree.PredicateBase predicate);
        IOrState Or();
        IOrExpressionState Or(string expression);
        IPredicateDisjunctionState Or(Tree.PredicateBase predicate);
    }
}