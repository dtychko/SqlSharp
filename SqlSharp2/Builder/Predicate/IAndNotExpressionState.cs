using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Predicate
{
    public interface IAndNotExpressionState
    {
        IPredicateConjuctionState Compare(object value, BinaryOperationType operationType);
        IPredicateConjuctionState Compare(QueryBase query, BinarySubQueryOperationType operationType,
            SubQueryQuantifier quantifier);
    }
}