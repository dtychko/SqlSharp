using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Predicate
{
    internal class AndExpressionState : PredicateExpressionStateBase, IAndExpressionState, IAndNotExpressionState
    {
        private readonly bool _negate;


        public AndExpressionState(Tree.Predicate predicate, string expression)
            : this(predicate, expression, false)
        {
        }

        public AndExpressionState(Tree.Predicate predicate, string expression, bool negate)
            : base(predicate, expression)
        {
            _negate = negate;
        }


        public IPredicateConjuctionState Compare(object value, BinaryOperationType operationType)
        {
            Argument.NotNull(value, "value");
            var predicate = new BinaryPredicate(Expression, value, operationType);
            return PredicateConjuctionState(predicate, _negate);
        }
        
        public IPredicateConjuctionState Compare(IQuery query, BinarySubQueryOperationType operationType, SubQueryQuantifier quantifier)
        {
            Argument.NotNull(query, "query");
            var predicate = new BinarySubQueryPredicate(Expression, query, operationType, quantifier);
            return PredicateConjuctionState(predicate, _negate);
        }

        public IPredicateConjuctionState IsNull()
        {
            var predicate = new UnaryPredicate(Expression, UnaryOperationType.IsNull);
            return PredicateConjuctionState(predicate, _negate);
        }

        public IPredicateConjuctionState IsNotNull()
        {
            var predicate = new UnaryPredicate(Expression, UnaryOperationType.IsNotNull);
            return PredicateConjuctionState(predicate, _negate);
        }
    }
}