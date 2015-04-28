namespace SqlSharp2.Tree
{
    public class SubQueryTableSource : AliasedTableSource
    {
        public IQuery Query { get; private set; }


        internal SubQueryTableSource(IQuery query)
            : this(query, null)
        {
        }

        internal SubQueryTableSource(IQuery query, string alias)
            : base(alias)
        {
            Query = Argument.NotNull(query, "query");
        }


        protected internal override AliasedTableSource As(string alias)
        {
            return new SubQueryTableSource(Query, alias);
        }

        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitSubQueryTableSource(this);
        }
    }
}
