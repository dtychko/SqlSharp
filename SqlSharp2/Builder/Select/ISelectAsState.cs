using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Select
{
    public interface ISelectAsState
    {
        ISelectState Select(string column);
        IFromState From(string table);
        IFromState From(IQuery subquery);
    }
}