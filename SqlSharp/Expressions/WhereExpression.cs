namespace SqlSharp.Expressions
{
    public class WhereExpression : Expression
    {
        #region Properties

        public string Value { get; private set; }

        #endregion

        #region Ctors

        internal WhereExpression(string value)
            : base(ExpressionType.Where)
        {
            Value = Argument.NotEmpty(value, "value");
        }

        #endregion

        #region Methods

        protected internal override void Accept(ExpressionVisitor visitor)
        {
            visitor.VisitWhere(this);
        }

        #endregion
    }
}
