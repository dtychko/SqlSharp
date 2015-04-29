namespace SqlSharp2.Builder.Predicate
{
    internal class PredicateDisjunctionState : PredicateBuilderState, IPredicateDisjunctionState
    {
        public PredicateDisjunctionState(Tree.PredicateBase predicate)
            : base(predicate)
        {
        }


        public IOrState Or()
        {
            return TransientOrState();
        }

        public IOrExpressionState Or(string expression)
        {
            Argument.NotWhiteSpace(expression, "expression");
            return OrState(expression);
        }

        public IPredicateDisjunctionState Or(Tree.PredicateBase predicate)
        {
            Argument.NotNull(predicate, "predicate");
            return PredicateDisjunctionState(predicate);
        }
    }
}