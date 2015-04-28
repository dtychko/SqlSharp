namespace SqlSharp2.Builder.Predicate
{
    public interface IPredicateConjuctionState : IPredicateBuilder
    {
        IAndState And();
        IAndExpressionState And(string expression);
        IPredicateConjuctionState And(Tree.Predicate predicate);
    }
}