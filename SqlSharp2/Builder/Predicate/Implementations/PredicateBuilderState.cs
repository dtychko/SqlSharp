using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Predicate
{
    internal abstract class PredicateBuilderState : PredicateState, IPredicateBuilder
    {
        protected PredicateBuilderState(PredicateBase predicate)
            : base(predicate)
        {
        }


        public PredicateBase AsPredicate()
        {
            return Predicate;
        }
    }
}