using SqlSharp2.Tree;

namespace SqlSharp2.Builder
{
    public interface IQueryState
    {
        Query AsQuery();
    }
}