namespace SqlSharp2.Builder.Select
{
    public interface IOrderByInDirectionState : ISelectStatementBuilder
    {
        IOrderByState OrderBy(string column);
    }
}