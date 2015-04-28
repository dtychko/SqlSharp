namespace SqlSharp2.Builder.Predicate
{
    internal abstract class PredicateBuilderState : PredicateState, IPredicateBuilder
    {
        protected PredicateBuilderState(Tree.Predicate predicate)
            : base(predicate)
        {
        }


        public Tree.Predicate AsPredicate()
        {
            return Predicate;
        }
    }
}