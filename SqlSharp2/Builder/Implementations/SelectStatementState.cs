using SqlSharp2.Tree;

namespace SqlSharp2.Builder
{
    internal abstract class SelectStatementState : State, ISelectStatementState
    {
        protected SelectStatement Statement { get; private set; }


        protected SelectStatementState(SelectStatement statement)
        {
            Statement = Argument.NotNull(statement, "statement");
        }


        public SelectStatement AsStatement()
        {
            return Statement;
        }
    }
}