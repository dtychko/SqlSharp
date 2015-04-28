namespace SqlSharp2.Builder
{
    public interface IOrderByInDirectionState : ISelectStatementState
    {
        IOrderByState OrderBy(string column);
    }
}