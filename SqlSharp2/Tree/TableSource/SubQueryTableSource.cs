namespace SqlSharp2.Tree
{
    public class SubQueryTableSource : AliasedTableSource
    {
        public QueryBase Query { get; private set; }


        internal SubQueryTableSource(QueryBase query)
            : this(query, null)
        {
        }

        internal SubQueryTableSource(QueryBase query, string alias)
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
