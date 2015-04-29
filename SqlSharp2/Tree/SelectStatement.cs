namespace SqlSharp2.Tree
{
    public class SelectStatement : TreeNode
    {
        public Query Query { get; private set; }

        public OrderList Order { get; private set; }


        internal SelectStatement(Query query)
            : this(query, OrderList.Empty)
        {
        }

        internal SelectStatement(Query query, OrderList order)
        {
            Query = Argument.NotNull(query, "query");
            Order = order;
        }

        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitSelectStatement(this);
        }
    }
}
