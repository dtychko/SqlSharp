namespace SqlSharp.Expressions
{
    public class ColumnNameExpression : Expression
    {
        #region Properties

        public string Value { get; private set; }

        #endregion

        #region Ctors

        internal ColumnNameExpression(string value)
            : base(ExpressionType.ColumnName)
        {
            Value = Argument.NotWhiteSpace(value, "value");
        }

        #endregion

        #region Methods

        protected internal override void Accept(ExpressionVisitor visitor)
        {
            visitor.VisitColumnName(this);
        }

        #endregion
    }
}
