namespace SqlSharp2.Builder.Predicate
{
    internal abstract class PredicateBuilderState : PredicateState, IPredicateBuilder
    {
        protected PredicateBuilderState(Tree.PredicateBase predicate)
            : base(predicate)
        {
        }


        public Tree.PredicateBase AsPredicate()
        {
            return Predicate;
        }
    }
}