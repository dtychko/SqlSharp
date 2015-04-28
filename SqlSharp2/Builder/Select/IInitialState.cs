namespace SqlSharp2.Builder.Select
{
    public interface IInitialState
    {
        ISelectState Select(string column);
    }
}
