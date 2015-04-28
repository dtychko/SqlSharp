namespace SqlSharp2.Tree
{
    public class InSubQueryPredicate : SubQueryPredicate
    {
        public object Expression { get; private set; }


        public InSubQueryPredicate(object expression, IQuery query)
            : base(query)
        {
            Expression = Argument.NotNull(expression, "expression");
        }


        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitInSubQueryPredicate(this);
        }
    }
}