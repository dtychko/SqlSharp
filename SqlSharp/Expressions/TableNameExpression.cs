namespace SqlSharp.Expressions
{
    public class TableNameExpression : Expression
    {
        #region Properties

        public string Value { get; private set; }

        #endregion

        #region Ctors

        internal TableNameExpression(string value)
            : base(ExpressionType.TableName)
        {
            Value = Argument.NotWhiteSpace(value, "value");
        }

        #endregion

        #region Methods

        protected internal override void Accept(ExpressionVisitor visitor)
        {
            visitor.VisitTableName(this);
        }

        #endregion
    }
}
