using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Predicate
{
    public static class Predicate
    {
        private static readonly IInitialState InitialState = new InitialState();


        public static IForState For(string expression)
        {
            return InitialState.For(expression);
        }

        public static INotForState Not(string expression)
        {
            return InitialState.Not(expression);
        }

        public static INotInitialState Not()
        {
            return InitialState.Not();
        }

        public static ISinglePredicateState Exists(IQuery query)
        {
            return InitialState.Exists(query);
        }


        public static PredicateConjuction And(PredicateBase left, PredicateBase right)
        {
            Argument.NotNull(left, "left");
            Argument.NotNull(right, "right");
            return new PredicateConjuction(left, right);
        }

        public static PredicateDisjunction Or(PredicateBase left, PredicateBase right)
        {
            Argument.NotNull(left, "left");
            Argument.NotNull(right, "right");
            return new PredicateDisjunction(left, right);
        }

        public static PredicateBase Not(PredicateBase predicate)
        {
            Argument.NotNull(predicate, "predicate");
            return new NotPredicate(predicate);
        }
    }
}
