﻿using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Predicate
{
    public interface IAndExpressionState
    {
        IPredicateConjuctionState Compare(object value, BinaryOperationType operationType);
        IPredicateConjuctionState Compare(IQuery query, BinarySubQueryOperationType operationType,
            SubQueryQuantifier quantifier);
        IPredicateConjuctionState IsNull();
        IPredicateConjuctionState IsNotNull();
    }
}