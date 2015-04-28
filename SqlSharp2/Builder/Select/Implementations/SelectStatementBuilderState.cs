using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Select
{
    internal abstract class SelectStatementBuilderState : State, ISelectStatementBuilder
    {
        protected SelectStatement Statement { get; private set; }


        protected SelectStatementBuilderState(SelectStatement statement)
        {
            Statement = Argument.NotNull(statement, "statement");
        }


        public SelectStatement AsStatement()
        {
            return Statement;
        }
    }
}