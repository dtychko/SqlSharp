namespace SqlSharp.Expressions
{
    public class NameExpression : Expression
    {
        #region Properties

        public string Value { get; private set; }

        #endregion

        #region Ctors

        internal NameExpression(string value)
            : base(ExpressionType.Name)
        {
            Value = Argument.NotWhiteSpace(value, "value");
        }

        #endregion

        #region Methods

        protected internal override void Accept(ExpressionVisitor visitor)
        {
            visitor.VisitName(this);
        }

        #endregion
    }
}
