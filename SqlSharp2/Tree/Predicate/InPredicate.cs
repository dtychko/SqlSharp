namespace SqlSharp2.Tree
{
    public class InPredicate : PredicateBase
    {
        public object Expression { get; private set; }

        public object[] Values { get; private set; }


        internal InPredicate(object expression, object[] values)
        {
            Expression = Argument.NotNull(expression, "expression");
            Values = Argument.NotEmpty(values, "values");
        }


        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitInPredicate(this);
        }
    }
}