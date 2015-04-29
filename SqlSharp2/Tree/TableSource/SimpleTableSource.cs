namespace SqlSharp2.Tree
{
    public class SimpleTableSource : AliasedTableSource
    {
        public string Table { get; private set; }


        internal SimpleTableSource(string table)
            : this(table, null)
        {
        }

        internal SimpleTableSource(string table, string alias)
            : base(alias)
        {
            Table = Argument.NotNull(table, "table");
        }


        protected internal override AliasedTableSource As(string alias)
        {
            return new SimpleTableSource(Table, alias);
        }

        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitSimpleTableSource(this);
        }
    }
}