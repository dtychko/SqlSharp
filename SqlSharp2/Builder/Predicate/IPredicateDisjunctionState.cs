namespace SqlSharp2.Builder.Predicate
{
    public interface IPredicateDisjunctionState : IPredicateBuilder
    {
        IOrState Or();
        IOrExpressionState Or(string expression);
        IPredicateDisjunctionState Or(Tree.PredicateBase predicate);
    }
}