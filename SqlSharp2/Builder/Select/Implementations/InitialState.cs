using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Select
{
    internal class InitialState : State, IInitialState
    {
        public ISelectState Select(string column)
        {
            Argument.NotWhiteSpace(column, "column");
            var query = Query.Empty.AddColumn(column);
            return new SelectState(query);
        }
    }
}