namespace SqlSharp.Builder
{
    public interface ISelectAsState
    {
        ISelectState Select(string column);
        IFromState From(string table);
    }
}