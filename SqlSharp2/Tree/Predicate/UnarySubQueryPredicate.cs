namespace SqlSharp2.Tree
{
    public class UnarySubQueryPredicate : SubQueryPredicate
    {
        public UnarySubQueryOperationType OperationType { get; private set; }


        internal UnarySubQueryPredicate(QueryBase query, UnarySubQueryOperationType operationType)
            : base(query)
        {
            OperationType = operationType;
        }


        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitUnarySubQueryPredicate(this);
        }
    }
}