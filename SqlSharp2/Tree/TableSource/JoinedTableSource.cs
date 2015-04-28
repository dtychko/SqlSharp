namespace SqlSharp2.Tree
{
    public class JoinedTableSource : TableSourceBase
    {
        public TableSourceBase Left { get; private set; }

        public TableSourceBase Right { get; private set; }

        public StringPredicate On { get; private set; }

        public JoinType Type { get; private set; }


        internal JoinedTableSource(TableSourceBase left, TableSourceBase right, StringPredicate on, JoinType type)
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