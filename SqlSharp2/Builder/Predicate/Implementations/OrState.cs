using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Predicate
{
    internal class OrState : PredicateState, IOrState, IOrNotState
    {
        private readonly bool _negate;


        public OrState(Tree.Predicate predicate)
            : this(predicate, false)
        {
        }

        public OrState(Tree.Predicate predicate, bool negate)
            : base(predicate)
        {
            _negate = negate;
        }


        public IOrNotState Not()
        {
            return TransientOrNotState();
        }

        public IOrNotExpressionState Not(string expression)
        {
            return OrNotState(expression);
        }

        public IPredicateDisjunctionState Exists(IQuery query)
        {
            Argument.NotNull(query, "query");
            var predicate = new UnarySubQueryPredicate(query, UnarySubQueryOperationType.Exists);
            return PredicateDisjunctionState(predicate, _negate);
        }
    }
}