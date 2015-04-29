namespace SqlSharp2.Tree
{
    public class ColumnOrder : OrderBase
    {
        public string Column { get; private set; }


        internal ColumnOrder(string column)
            : this(column, OrderDirection.Default)
        {
        }

        internal ColumnOrder(string column, OrderDirection direction)
            : base(direction)
        {
            Column = Argument.NotWhiteSpace(column, "column");
        }


        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitColumnOrder(this);
        }
    }
}