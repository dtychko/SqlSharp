namespace SqlSharp2.Tree
{
    public class BinaryPredicate : Predicate
    {
        public object Left { get; private set; }

        public object Right { get; private set; }
        
        public BinaryOperationType OperationType { get; private set; }


        internal BinaryPredicate(object left, object right, BinaryOperationType operationType)
        {
            Left = Argument.NotNull(left, "left");
            Right = Argument.NotNull(right, "right");
            OperationType = operationType;
        }


        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitBinaryPredicate(this);
        }
    }
}