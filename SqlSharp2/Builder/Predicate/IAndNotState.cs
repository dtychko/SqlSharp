using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Predicate
{
    public interface IAndNotState
    {
        IPredicateConjuctionState Exists(IQuery subQuery);
    }
}