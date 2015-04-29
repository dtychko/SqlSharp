using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Predicate
{
    public interface IOrNotState
    {
        IPredicateDisjunctionState Exists(QueryBase subQuery);
    }
}