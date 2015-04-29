using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Select
{
    public interface IJoinAsState
    {
        IJoinOnState On(PredicateBase predicate);
    }
}