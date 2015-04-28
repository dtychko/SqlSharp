using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Predicate.Implementations
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


        #region Extension Methods

        public static ISinglePredicateState Eq(this IForState state, object value)
        {
            Argument.NotNull(state, "state");
            return state.Compare(value, BinaryOperationType.Eq);
        }

        public static ISinglePredicateState Eq(this INotForState state, object value)
        {
            Argument.NotNull(state, "state");
            return state.Compare(value, BinaryOperationType.Eq);
        }

        public static IPredicateConjuctionState Eq(this IAndState state, object value)
        {
            Argument.NotNull(state, "state");
            return state.Compare(value, BinaryOperationType.Eq);
        }

        public static IPredicateConjuctionState Eq(this IAndNotState state, object value)
        {
            Argument.NotNull(state, "state");
            return state.Compare(value, BinaryOperationType.Eq);
        }

        public static IPredicateDisjunctionState Eq(this IOrState state, object value)
        {
            Argument.NotNull(state, "state");
            return state.Compare(value, BinaryOperationType.Eq);
        }

        public static IPredicateDisjunctionState Eq(this IOrNotState state, object value)
        {
            Argument.NotNull(state, "state");
            return state.Compare(value, BinaryOperationType.Eq);
        }

        #endregion
    }
}
