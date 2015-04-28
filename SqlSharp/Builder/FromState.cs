using SqlSharp.Expressions;

namespace SqlSharp.Builder
{
    internal class FromState : IFromState, IFromAsState, IJoinOnState
    {
        private readonly Expression _selectExpression;
        private readonly Expression _fromExpression;


        public Expression Expression
        {
            get { return new SqlSelectExpression(_selectExpression, _fromExpression, null); }
        }


        internal FromState(Expression selectExpression, Expression fromExpression)
        {
            _selectExpression = Argument.NotNull(selectExpression, "selectExpression");
            _fromExpression = Argument.NotNull(fromExpression, "fromExpression");
        }


        public IFromState From(string table)
        {
            Argument.NotWhiteSpace(table, "table");
            var tableNameExpression = new TableNameExpression(table);
            var fromExpression = Expression.ListTables(_fromExpression, tableNameExpression);
            return new FromState(_selectExpression, fromExpression);
        }

        public IFromAsState As(string alias)
        {
            Argument.NotWhiteSpace(alias, "alias");
            var fromExpression = Expression.AddAlias(_fromExpression, alias);
            return new FromState(_selectExpression, fromExpression);
        }

        public IJoinState Join(string table, JoinType joinType)
        {
            Argument.NotWhiteSpace(table, "table");
            return new JoinState(_selectExpression, _fromExpression, new TableNameExpression(table), joinType);
        }
    }
}
