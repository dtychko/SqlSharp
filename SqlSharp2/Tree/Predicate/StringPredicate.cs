namespace SqlSharp2.Tree
{
    public class StringPredicate : TreeNode
    {
        public string Value { get; private set; }


        internal StringPredicate(string value)
        {
            Value = Argument.NotWhiteSpace(value, "value");
        }


        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitPredicate(this);
        }
    }
}
