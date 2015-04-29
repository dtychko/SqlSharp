using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Predicate
{
    internal class OrExpressionState : PredicateExpressionStateBase, IOrExpressionState, IOrNotExpressionState
    {
        private readonly bool _negate;


        public OrExpressionState(Tree.PredicateBase predicate, string expression)
            : this(predicate, expression, false)
        {
        }

        public OrExpressionState(Tree.PredicateBase predicate, string expression, bool negate)
            : base(predicate, expression)
        {
            _negate = negate;
        }


        public IPredicateDisjunctionState Compare(object value, BinaryOperationType operationType)
        {
            Argument.NotNull(value, "value");
            var predicate = new BinaryPredicate(Expression, value, operationType);
            return PredicateDisjunctionState(predicate, _negate);
        }

        public IPredicateDisjunctionState Compare(IQuery query, BinarySubQueryOperationType operationType,
            SubQueryQuantifier quantifier)
        {
            Argument.NotNull(query, "query");
            var predicate = new BinarySubQueryPredicate(Expression, query, operationType, quantifier);
            return PredicateDisjunctionState(predicate, _negate);
        }

        public IPredicateDisjunctionState IsNull()
        {
            var predicate = new UnaryPredicate(Expression, UnaryOperationType.IsNull);
            return PredicateDisjunctionState(predicate, _negate);
        }

        public IPredicateDisjunctionState IsNotNull()
        {
            var predicate = new UnaryPredicate(Expression, UnaryOperationType.IsNotNull);
            return PredicateDisjunctionState(predicate, _negate);
        }
    }
}