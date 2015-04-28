using System;

namespace SqlSharp.Expressions
{
    public abstract class Expression
    {
        #region Static Members

        public static BinaryExpression AddAlias(Expression expression, string alias)
        {
            Argument.NotNull(expression, "expression");
            Argument.NotWhiteSpace(alias, "alias");
            if (expression is ColumnNameExpression ||
                expression is TableNameExpression)
            {
                var result = new BinaryExpression(
                    expression,
                    new NameExpression(alias),
                    ExpressionType.Column);
                return result;
            }
            var binaryExpression = expression as BinaryExpression;
            if (binaryExpression != null)
            {
                if (binaryExpression.Right is ColumnNameExpression ||
                    binaryExpression.Right is TableNameExpression)
                {
                    var result = new BinaryExpression(
                        binaryExpression.Left,
                        new BinaryExpression(
                            binaryExpression.Right,
                            new NameExpression(alias),
                            ExpressionType.Column),
                        ExpressionType.ColumnList);
                    return result;
                }
            }
            throw new InvalidOperationException("Alias couldn't be add to provided expression.");
        }

        public static TableJoinExpression JoinTables(Expression left, Expression right, Expression condition,
            JoinType joinType)
        {
            Argument.NotNull(left, "left");
            Argument.NotNull(right, "right");
            Argument.NotNull(condition, "condition");
            var result = new TableJoinExpression(left, right, condition, joinType);
            return result;
        }

        public static BinaryExpression ListColumns(Expression left, Expression right)
        {
            Argument.NotNull(left, "left");
            Argument.NotNull(right, "right");
            // TODO: validate left/right expresion type.
            var result = new BinaryExpression(left, right, ExpressionType.ColumnList);
            return result;
        }

        public static BinaryExpression ListTables(Expression left, Expression right)
        {
            Argument.NotNull(left, "left");
            Argument.NotNull(right, "right");
            // TODO: validate left/right expresion type.
            var result = new BinaryExpression(left, right, ExpressionType.TableList);
            return result;
        }

        #endregion

        #region Properties

        public ExpressionType NodeType { get; private set; }

        #endregion

        #region Ctors

        protected Expression(ExpressionType nodeType)
        {
            NodeType = nodeType;
        }

        #endregion

        #region Methods

        protected internal abstract void Accept(ExpressionVisitor visitor);

        #endregion
    }
}
