using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Predicate
{
    public interface IOrExpressionState
    {
        IPredicateDisjunctionState Compare(object value, BinaryOperationType operationType);
        IPredicateDisjunctionState Compare(QueryBase query, BinarySubQueryOperationType operationType,
            SubQueryQuantifier quantifier);
        IPredicateDisjunctionState IsNull();
        IPredicateDisjunctionState IsNotNull();
    }
}