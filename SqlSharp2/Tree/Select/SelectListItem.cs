namespace SqlSharp2.Tree
{
    public class SelectListItem : TreeNode, IProjection
    {
        public string Column { get; private set; }

        public string Alias { get; private set; }


        internal SelectListItem(string column)
            : this(column, null)
        {
        }

        internal SelectListItem(string column, string alias)
        {
            Column = Argument.NotWhiteSpace(column, "column");
            Alias = alias;
        }


        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitSelectListItem(this);
        }
    }
}