using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Predicate
{
    internal class PredicateConjuctionState : PredicateBuilderState, IPredicateConjuctionState
    {
        public PredicateConjuctionState(PredicateBase predicate)
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

        public IPredicateConjuctionState And(PredicateBase predicate)
        {
            Argument.NotNull(predicate, "predicate");
            return PredicateConjuctionState(predicate);
        }
    }
}