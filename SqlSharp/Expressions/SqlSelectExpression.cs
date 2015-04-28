namespace SqlSharp.Expressions
{
    public class SqlSelectExpression : Expression
    {
        #region Properties

        public Expression Select { get; private set; }

        public Expression From { get; private set; }

        public Expression Where { get; private set; }

        #endregion

        #region Ctors

        internal SqlSelectExpression(Expression select, Expression from, Expression where)
            : base(ExpressionType.SqlSelect)
        {
            Select = Argument.NotNull(select, "select");
            From = Argument.NotNull(from, "from");
            Where = where;
        }

        #endregion

        #region Methods

        protected internal override void Accept(ExpressionVisitor visitor)
        {
            visitor.VisitSqlSelect(this);
        }

        #endregion
    }
}
