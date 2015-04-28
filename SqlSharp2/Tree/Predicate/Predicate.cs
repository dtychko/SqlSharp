using System.Collections.Immutable;

namespace SqlSharp2.Tree
{
    public abstract class Predicate : TreeNode
    {
        public static PredicateConjuction And(Predicate left, Predicate right)
        {
            Argument.NotNull(left, "left");
            Argument.NotNull(right, "right");
            var predicates = ImmutableList<Predicate>.Empty.Add(left).Add(right);
            return new PredicateConjuction(predicates);
        }

        public static PredicateDisjunction Or(Predicate left, Predicate right)
        {
            Argument.NotNull(left, "left");
            Argument.NotNull(right, "right");
            var predicates = ImmutableList<Predicate>.Empty.Add(left).Add(right);
            return new PredicateDisjunction(predicates);
        }

        public static Predicate Not(Predicate predicate)
        {
            Argument.NotNull(predicate, "predicate");
            var result = new NotPredicate(predicate);
            return result;
        }
    }
}
