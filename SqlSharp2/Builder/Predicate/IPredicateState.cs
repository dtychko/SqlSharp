using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Predicate
{
    public interface IPredicateState
    {
        Tree.Predicate AsPredicate();
    }

    public interface IInitialState
    {
        IForState For(string expression);
        INotForState Not(string expression);
        INotInitialState Not();
        ISinglePredicateState Exists(IQuery query);
    }

    public interface INotInitialState
    {
        ISinglePredicateState Exists(IQuery query);
    }

    public interface IForState
    {
        ISinglePredicateState Compare(object value, BinaryOperationType operationType);
        ISinglePredicateState Compare(IQuery query, BinarySubQueryOperationType operationType,
            SubQueryQuantifier quantifier);
        ISinglePredicateState IsNull();
        ISinglePredicateState IsNotNull();
    }

    public interface INotForState
    {
        ISinglePredicateState Compare(object value, BinaryOperationType operationType);
        ISinglePredicateState Compare(IQuery query, BinarySubQueryOperationType operationType,
            SubQueryQuantifier quantifier);
    }

    public interface ISinglePredicateState : IPredicateState
    {
        ITransientAndState And();
        IAndState And(string expression);
        IPredicateConjuctionState And(Tree.Predicate predicate);
        ITransientOrState Or();
        IOrState Or(string expression);
        IPredicateDisjunctionState Or(Tree.Predicate predicate);
    }

    public interface ITransientAndState
    {
        ITransientAndNotState Not();
        IAndNotState Not(string expression);
        IPredicateConjuctionState Exists(IQuery query);
    }

    public interface ITransientAndNotState
    {
        IPredicateConjuctionState Exists(IQuery subQuery);
    }

    public interface IAndState
    {
        IPredicateConjuctionState Compare(object value, BinaryOperationType operationType);
        IPredicateConjuctionState Compare(IQuery query, BinarySubQueryOperationType operationType,
            SubQueryQuantifier quantifier);
        IPredicateConjuctionState IsNull();
        IPredicateConjuctionState IsNotNull();
    }

    public interface IAndNotState
    {
        IPredicateConjuctionState Compare(object value, BinaryOperationType operationType);
        IPredicateConjuctionState Compare(IQuery query, BinarySubQueryOperationType operationType,
            SubQueryQuantifier quantifier);
    }

    public interface IPredicateConjuctionState : IPredicateState
    {
        ITransientAndState And();
        IAndState And(string expression);
        IPredicateConjuctionState And(Tree.Predicate predicate);
    }

    public interface ITransientOrState
    {
        ITransientOrNotState Not();
        IOrNotState Not(string expression);
        IPredicateDisjunctionState Exists(IQuery query);
    }

    public interface ITransientOrNotState
    {
        IPredicateDisjunctionState Exists(IQuery subQuery);
    }

    public interface IOrState
    {
        IPredicateDisjunctionState Compare(object value, BinaryOperationType operationType);
        IPredicateDisjunctionState Compare(IQuery query, BinarySubQueryOperationType operationType,
            SubQueryQuantifier quantifier);
        IPredicateDisjunctionState IsNull();
        IPredicateDisjunctionState IsNotNull();
    }

    public interface IOrNotState
    {
        IPredicateDisjunctionState Compare(object value, BinaryOperationType operationType);
        IPredicateDisjunctionState Compare(IQuery query, BinarySubQueryOperationType operationType,
            SubQueryQuantifier quantifier);
    }

    public interface IPredicateDisjunctionState : IPredicateState
    {
        ITransientOrState Or();
        IOrState Or(string expression);
        IPredicateDisjunctionState Or(Tree.Predicate predicate);
    }
}
