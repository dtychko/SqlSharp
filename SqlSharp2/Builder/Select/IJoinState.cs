using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Select
{
    public interface IJoinState
    {
        IJoinAsState As(string alias);
        IJoinOnState On(PredicateBase predicate);
    }
}