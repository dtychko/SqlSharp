namespace SqlSharp.Expressions
{
    public class TableJoinExpression : Expression
    {
        #region Properties

        public Expression Left { get; private set; }

        public Expression Right { get; private set; }

        public Expression Condition { get; private set; }

        public JoinType JoinType { get; private set; }

        #endregion

        #region Ctors

        internal TableJoinExpression(Expression left, Expression right, Expression condition, JoinType joinType)
            : base(ExpressionType.TableJoin)
        {
            Left = Argument.NotNull(left, "left");
            Right = Argument.NotNull(right, "right");
            Condition = Argument.NotNull(condition, "condition");
            JoinType = joinType;
        }

        #endregion

        #region Methods

        protected internal override void Accept(ExpressionVisitor visitor)
        {
            visitor.VisitTableJoin(this);
        }

        #endregion
    }
}
