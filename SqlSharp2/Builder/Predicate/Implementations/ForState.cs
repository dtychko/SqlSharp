using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Predicate
{
    internal class ForState : State, IForState, INotForState
    {
        private readonly string _expression;
        private readonly bool _negate;


        public ForState(string expression)
            : this(expression, false)
        {
        }

        public ForState(string expression, bool negate)
        {
            _expression = Argument.NotWhiteSpace(expression, "expression");
            _negate = negate;
        }


        public ISinglePredicateState Compare(object value, BinaryOperationType operationType)
        {
            Argument.NotNull(value, "value");
            var predicate = new BinaryPredicate(_expression, value, operationType);
            return InitialPredicateState(predicate, _negate);
        }

        public ISinglePredicateState Compare(IQuery query, BinarySubQueryOperationType operationType, SubQueryQuantifier quantifier)
        {
            Argument.NotNull(query, "query");
            var predicate = new BinarySubQueryPredicate(_expression, query, operationType, quantifier);
            return InitialPredicateState(predicate, _negate);
        }

        public ISinglePredicateState IsNull()
        {
            var predicate = new UnaryPredicate(_expression, UnaryOperationType.IsNull);
            return InitialPredicateState(predicate, _negate);
        }

        public ISinglePredicateState IsNotNull()
        {
            var predicate = new UnaryPredicate(_expression, UnaryOperationType.IsNull);
            return InitialPredicateState(predicate, _negate);
        }
    }
}