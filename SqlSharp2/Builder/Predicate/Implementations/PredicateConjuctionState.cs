namespace SqlSharp2.Builder.Predicate
{
    internal class PredicateConjuctionState : PredicateBuilderState, IPredicateConjuctionState
    {
        public PredicateConjuctionState(Tree.PredicateBase predicate)
            : base(predicate)
        {
        }

        public IAndState And()
        {
            return TransientAndState();
        }

        public IAndExpressionState And(string expression)
        {
            Argument.NotWhiteSpace(expression, "expression");
            return AndState(expression);
        }

        public IPredicateConjuctionState And(Tree.PredicateBase predicate)
        {
            Argument.NotNull(predicate, "predicate");
            return PredicateConjuctionState(predicate);
        }
    }
}