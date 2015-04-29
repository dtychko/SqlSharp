namespace SqlSharp2.Tree
{
    public class BinarySubQueryPredicate : SubQueryPredicate
    {
        public object Expression { get; private set; }

        public BinarySubQueryOperationType OperationType { get; private set; }

        public SubQueryQuantifier Quantifier { get; private set; }


        internal BinarySubQueryPredicate(object expression, QueryBase query, BinarySubQueryOperationType operationType)
            : this(expression, query, operationType, SubQueryQuantifier.None)
        {
        }

        internal BinarySubQueryPredicate(object expression, QueryBase query, BinarySubQueryOperationType operationType, SubQueryQuantifier quantifier)
            : base(query)
        {
            Expression = Argument.NotNull(expression, "expression");
            OperationType = operationType;
            Quantifier = quantifier;
        }


        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitBinarySubQueryPredicate(this);
        }
    }
}