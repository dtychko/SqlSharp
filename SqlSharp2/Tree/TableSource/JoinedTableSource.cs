namespace SqlSharp2.Tree
{
    public class JoinedTableSource : TreeNode, ITableSource
    {
        public ITableSource Left { get; private set; }

        public ITableSource Right { get; private set; }

        public StringPredicate On { get; private set; }

        public JoinType Type { get; private set; }


        internal JoinedTableSource(ITableSource left, ITableSource right, StringPredicate on, JoinType type)
        {
            Left = Argument.NotNull(left, "left");
            Right = Argument.NotNull(right, "right");
            On = Argument.NotNull(on, "on");
            Type = type;
        }


        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitJoinedTableSource(this);
        }
    }
}