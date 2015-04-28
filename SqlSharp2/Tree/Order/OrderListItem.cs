namespace SqlSharp2.Tree
{
    public class OrderListItem : TreeNode, IOrderListItem
    {
        public string Column { get; private set; }

        public OrderDirection Direction { get; private set; }


        internal OrderListItem(string column)
            : this(column, OrderDirection.Default)
        {
        }

        internal OrderListItem(string column, OrderDirection direction)
        {
            Column = Argument.NotWhiteSpace(column, "column");
            Direction = direction;
        }


        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitOrderByListItem(this);
        }
    }
}