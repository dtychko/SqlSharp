using SqlSharp.Expressions;

namespace SqlSharp.Builder
{
    internal class JoinState : IJoinState, IJoinAsState
    {
        private readonly Expression _selectExpression;
        private readonly Expression _fromExpression;
        private readonly Expression _joinWithExpression;
        private readonly JoinType _joinType;


        internal JoinState(Expression selectExpression, Expression fromExpression, Expression joinWithExpression, JoinType joinType)
        {
            _selectExpression = Argument.NotNull(selectExpression, "selectExpression");
            _fromExpression = Argument.NotNull(fromExpression, "fromExpression");
            _joinWithExpression = Argument.NotNull(joinWithExpression, "joinWithExpression");
            _joinType = joinType;
        }


        public IJoinAsState As(string alias)
        {
            Argument.NotWhiteSpace(alias, "alias");
            var joinWithExpression = Expression.AddAlias(_joinWithExpression, alias);
            return new JoinState(_selectExpression, _fromExpression, joinWithExpression, _joinType);
        }

        public IJoinOnState On(string condition)
        {
            Argument.NotWhiteSpace(condition, "condition");
            var conditionExpression = new WhereExpression(condition);
            var fromExpression = Expression.JoinTables(_fromExpression, _joinWithExpression,
                conditionExpression, _joinType);
            return new FromState(_selectExpression, fromExpression);
        }
    }
}
