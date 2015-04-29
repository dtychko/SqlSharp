using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Predicate
{
    internal abstract class State
    {
        protected ISinglePredicateState InitialPredicateState(PredicateBase predicate, bool negate)
        {
            if (negate)
            {
                predicate = Predicate.Not(predicate);
            }
            return new SinglePredicateState(predicate);
        }
    }
}