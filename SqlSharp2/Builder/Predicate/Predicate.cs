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
    }
}
