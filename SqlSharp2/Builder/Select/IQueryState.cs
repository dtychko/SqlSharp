using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Select
{
    public interface IQueryState
    {
        Query AsQuery();
    }
}