namespace SqlSharp.Builder
{
    public interface ISelectState
    {
        ISelectState Select(string column);
        ISelectAsState As(string alias);
        IFromState From(string table);
    }
}