namespace SqlSharp2.Tree
{
    public class BetweenPredicate : Predicate
    {
        public object Expression { get; private set; }

        public object Low { get; private set; }

        public object High { get; private set; }


        internal BetweenPredicate(object expression, object low, object high)
        {
            Expression = Argument.NotNull(expression, "expression");
            Low = Argument.NotNull(low, "low");
            High = Argument.NotNull(high, "high");
        }


        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitBetweenPredicate(this);
        }
    }
}