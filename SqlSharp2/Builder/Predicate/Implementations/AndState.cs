using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Predicate
{
    internal class AndState : PredicateState, IAndState, IAndNotState
    {
        private readonly bool _negate;


        public AndState(PredicateBase predicate)
            : this(predicate, false)
        {
        }

        public AndState(PredicateBase predicate, bool negate)
            : base(predicate)
        {
            _negate = negate;
        }


        public IAndNotState Not()
        {
            return TransientAndNotState();
        }

        public IAndNotExpressionState Not(string expression)
        {
            return AndNotState(expression);
        }

        public IPredicateConjuctionState Exists(QueryBase query)
        {
            Argument.NotNull(query, "query");
            var predicate = new UnarySubQueryPredicate(query, UnarySubQueryOperationType.Exists);
            return PredicateConjuctionState(predicate, _negate);
        }
    }
}