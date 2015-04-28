namespace SqlSharp.Expressions
{
    public abstract class ExpressionVisitor
    {
        public void Visit(Expression expression)
        {
            expression.Accept(this);
        }


        protected internal virtual void VisitName(NameExpression expression)
        {
        }

        protected internal virtual void VisitColumnName(ColumnNameExpression expression)
        {
        }

        protected internal virtual void VisitTableName(TableNameExpression expression)
        {
        }

        protected internal virtual void VisitUnary(UnaryExpression expression)
        {
            Visit(expression.Operand);
        }

        protected internal virtual void VisitBinary(BinaryExpression expression)
        {
            Visit(expression.Left);
            Visit(expression.Right);
        }

        protected internal virtual void VisitTableJoin(TableJoinExpression expression)
        {
            Visit(expression.Left);
            Visit(expression.Right);
            Visit(expression.Condition);
        }

        protected internal virtual void VisitWhere(WhereExpression expression)
        {
        }

        protected internal virtual void VisitSqlSelect(SqlSelectExpression expression)
        {
            Visit(expression.Select);
            Visit(expression.From);
            if (expression.Where != null)
            {
                Visit(expression.Where);
            }
        }
    }
}
