namespace SqlSharp2.Tree
{
    public class SubQueryTableSource : TreeNode, ITableSource
    {
        public IQuery Query { get; private set; }

        public string Alias { get; private set; }


        internal SubQueryTableSource(IQuery query)
            : this(query, null)
        {
        }

        internal SubQueryTableSource(IQuery query, string alias)
        {
            Query = Argument.NotNull(query, "query");
            Alias = alias;
        }


        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitSubQueryTableSource(this);
        }
    }
}
