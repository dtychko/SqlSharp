namespace SqlSharp.Expressions
{
    public class UnaryExpression : Expression
    {
        #region Properties

        public Expression Operand { get; private set; }

        #endregion

        #region Ctors

        internal UnaryExpression(Expression operand, ExpressionType nodeType)
            : base(nodeType)
        {
            Operand = Argument.NotNull(operand, "operand");
        }

        #endregion

        #region Methods

        protected internal override void Accept(ExpressionVisitor visitor)
        {
            visitor.VisitUnary(this);
        }

        #endregion
    }
}
