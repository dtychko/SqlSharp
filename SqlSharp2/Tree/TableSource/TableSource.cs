namespace SqlSharp2.Tree
{
    public class TableSource : AliasedTableSource
    {
        public string Table { get; private set; }


        internal TableSource(string table)
            : this(table, null)
        {
        }

        internal TableSource(string table, string alias)
            : base(alias)
        {
            Table = Argument.NotNull(table, "table");
        }


        protected internal override AliasedTableSource As(string alias)
        {
            return new TableSource(Table, alias);
        }

        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitTableSource(this);
        }
    }
}