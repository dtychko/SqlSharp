namespace SqlSharp2.Tree
{
    public class TableSource : TreeNode, ITableSource
    {
        public string Table { get; private set; }

        public string Alias { get; private set; }


        internal TableSource(string table)
            : this(table, null)
        {
        }

        internal TableSource(string table, string alias)
        {
            Table = Argument.NotNull(table, "table");
            Alias = alias;
        }


        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitTableSource(this);
        }
    }
}