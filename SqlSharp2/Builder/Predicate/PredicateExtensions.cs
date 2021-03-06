﻿using SqlSharp2.Builder.Predicate;
using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Predicate
{
    public static class PredicateExtensions
    {
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

        public static IPredicateConjuctionState Eq(this IAndExpressionState state, object value)
        {
            Argument.NotNull(state, "state");
            return state.Compare(value, BinaryOperationType.Eq);
        }

        public static IPredicateConjuctionState Eq(this IAndNotExpressionState state, object value)
        {
            Argument.NotNull(state, "state");
            return state.Compare(value, BinaryOperationType.Eq);
        }

        public static IPredicateDisjunctionState Eq(this IOrExpressionState state, object value)
        {
            Argument.NotNull(state, "state");
            return state.Compare(value, BinaryOperationType.Eq);
        }

        public static IPredicateDisjunctionState Eq(this IOrNotExpressionState state, object value)
        {
            Argument.NotNull(state, "state");
            return state.Compare(value, BinaryOperationType.Eq);
        }
    }
}
