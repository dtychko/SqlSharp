namespace SqlSharp2.Builder.Predicate
{
    internal abstract class State
    {
        protected ISinglePredicateState InitialPredicateState(Tree.Predicate predicate, bool negate)
        {
            if (negate)
            {
                predicate = Tree.Predicate.Not(predicate);
            }
            return new SinglePredicateState(predicate);
        }
    }
}