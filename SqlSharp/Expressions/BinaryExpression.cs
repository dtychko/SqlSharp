namespace SqlSharp.Expressions
{
    public class BinaryExpression : Expression
    {
        #region Properties

        public Expression Left { get; private set; }

        public Expression Right { get; private set; }

        #endregion

        #region Ctors

        internal BinaryExpression(Expression left, Expression right, ExpressionType nodeType)
            : base(nodeType)
        {
            Left = Argument.NotNull(left, "left");
            Right = Argument.NotNull(right, "right");
        }

        #endregion

        #region Methods

        protected internal override void Accept(ExpressionVisitor visitor)
        {
            visitor.VisitBinary(this);
        }

        #endregion
    }
}
