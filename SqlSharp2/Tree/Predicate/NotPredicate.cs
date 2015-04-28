namespace SqlSharp2.Tree
{
    public class NotPredicate : Predicate
    {
        public Predicate Predicate { get; private set; }


        internal NotPredicate(Predicate predicate)
        {
            Predicate = Argument.NotNull(predicate, "predicate");
        }


        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitNotPredicate(this);
        }
    }
}