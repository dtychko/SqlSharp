namespace SqlSharp2.Tree
{
    public class UnaryPredicate : PredicateBase
    {
        public object Expression { get; private set; }

        public UnaryOperationType OperationType { get; private set; }


        internal UnaryPredicate(object expression, UnaryOperationType operationType)
        {
            Expression = Argument.NotNull(expression, "expression");
            OperationType = operationType;
        }


        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitUnaryPredicate(this);
        }
    }
}