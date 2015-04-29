namespace SqlSharp2.Tree
{
    public class ColumnProjection : AliasedProjection
    {
        public string Column { get; private set; }


        internal ColumnProjection(string column)
            : this(column, null)
        {
        }

        internal ColumnProjection(string column, string alias)
            : base(alias)
        {
            Column = Argument.NotWhiteSpace(column, "column");
        }


        protected internal override AliasedProjection As(string alias)
        {
            return new ColumnProjection(Column, alias);
        }

        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitColumnProjection(this);
        }
    }
}