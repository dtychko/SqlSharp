using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Predicate
{
    public interface IForState
    {
        ISinglePredicateState Compare(object value, BinaryOperationType operationType);
        ISinglePredicateState Compare(QueryBase query, BinarySubQueryOperationType operationType,
            SubQueryQuantifier quantifier);
        ISinglePredicateState IsNull();
        ISinglePredicateState IsNotNull();
    }
}