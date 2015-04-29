using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Predicate
{
    internal class InitialState : State, IInitialState, INotInitialState
    {
        private readonly bool _negate;


        public InitialState()
            : this(false)
        {
        }

        public InitialState(bool negate)
        {
            _negate = negate;
        }


        public IForState For(string expression)
        {
            Argument.NotWhiteSpace(expression, "expression");
            return new ForState(expression);
        }

        public INotForState Not(string expression)
        {
            Argument.NotWhiteSpace(expression, "expression");
            return new ForState(expression, true);
        }

        public INotInitialState Not()
        {
            return new InitialState(true);
        }

        public ISinglePredicateState Exists(QueryBase query)
        {
            Argument.NotNull(query, "query");
            var predicate = new UnarySubQueryPredicate(query, UnarySubQueryOperationType.Exists);
            return InitialPredicateState(predicate, _negate);
        }
    }
}
