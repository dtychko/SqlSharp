using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Predicate
{
    public interface INotInitialState
    {
        ISinglePredicateState Exists(IQuery query);
    }
}