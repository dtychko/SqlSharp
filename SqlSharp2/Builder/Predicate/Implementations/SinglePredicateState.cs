namespace SqlSharp2.Builder.Predicate
{
    internal class SinglePredicateState : PredicateBuilderState, ISinglePredicateState
    {
        public SinglePredicateState(Tree.Predicate predicate)
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

        public IPredicateConjuctionState And(Tree.Predicate predicate)
        {
            Argument.NotNull(predicate, "predicate");
            return PredicateConjuctionState(predicate);
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

        public IPredicateDisjunctionState Or(Tree.Predicate predicate)
        {
            Argument.NotNull(predicate, "predicate");
            return PredicateDisjunctionState(predicate);
        }
    }
}