using SqlSharp2.Tree;

namespace SqlSharp2.Builder
{
    public interface ISelectStatementState
    {
        SelectStatement AsStatement();
    }
}