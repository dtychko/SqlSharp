using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Predicate
{
    public interface INotForState
    {
        ISinglePredicateState Compare(object value, BinaryOperationType operationType);
        ISinglePredicateState Compare(IQuery query, BinarySubQueryOperationType operationType,
            SubQueryQuantifier quantifier);
    }
}