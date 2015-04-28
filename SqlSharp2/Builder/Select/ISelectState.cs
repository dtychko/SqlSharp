using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Select
{
    public interface ISelectState
    {
        ISelectState Select(string column);
        ISelectAsState As(string alias);
        IFromState From(string table);
        IFromState From(IQuery subquery);
    }
}