using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Predicate
{
    public interface IOrNotExpressionState
    {
        IPredicateDisjunctionState Compare(object value, BinaryOperationType operationType);
        IPredicateDisjunctionState Compare(QueryBase query, BinarySubQueryOperationType operationType,
            SubQueryQuantifier quantifier);
    }
}