namespace SqlSharp2.Tree
{
    public class NotPredicate : PredicateBase
    {
        public PredicateBase Predicate { get; private set; }


        internal NotPredicate(PredicateBase predicate)
        {
            Predicate = Argument.NotNull(predicate, "predicate");
        }


        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitNotPredicate(this);
        }
    }
}