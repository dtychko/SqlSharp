using SqlSharp2.Builder.Predicate;

namespace SqlSharp2.Tree
{
    internal static class PredicateHelper
    {
        public static PredicateConjuction AppendOrCreateConjuction(PredicateBase left, PredicateBase right)
        {
            var conjuction = left as PredicateConjuction;
            if (conjuction != null)
            {
                return conjuction.Add(right);
            }
            return Predicate.And(left, right);
        }

        public static PredicateDisjunction AppendOrCreateDisjunction(PredicateBase left, PredicateBase right)
        {
            var disjunction = left as PredicateDisjunction;
            if (disjunction != null)
            {
                return disjunction.Add(right);
            }
            return Predicate.Or(left, right);
        }
    }
}
