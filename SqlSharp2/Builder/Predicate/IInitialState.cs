using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Predicate
{
    public interface IInitialState
    {
        IForState For(string expression);
        INotForState Not(string expression);
        INotInitialState Not();
        ISinglePredicateState Exists(QueryBase query);
    }
}