using SqlSharp.Expressions;

namespace SqlSharp.Builder
{
    internal class SelectState : ISelectState, ISelectAsState
    {
        private readonly Expression _selectExpression;


        internal SelectState(Expression selectExpression)
        {
            _selectExpression = Argument.NotNull(selectExpression, "selectExpression");
        }


        public ISelectState Select(string column)
        {
            Argument.NotWhiteSpace(column, "column");
            var columnName = new ColumnNameExpression(column);
            var selectExpression = Expression.ListColumns(_selectExpression, columnName);
            return new SelectState(selectExpression);
        }

        public ISelectAsState As(string alias)
        {
            Argument.NotWhiteSpace(alias, "alias");
            var selectExpression = Expression.AddAlias(_selectExpression, alias);
            return new SelectState(selectExpression);
        }

        public IFromState From(string table)
        {
            Argument.NotWhiteSpace(table, "table");
            var fromExpression = new TableNameExpression(table);
            return new FromState(_selectExpression, fromExpression);
        }
    }
}
