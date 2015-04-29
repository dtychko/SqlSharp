using System.Collections.Immutable;

namespace SqlSharp2.Tree
{
    public class PredicateConjuction : PredicateJunction
    {
        internal static PredicateConjuction Empty
        {
            get { return new PredicateConjuction(ImmutableList<PredicateBase>.Empty); }
        }


        internal PredicateConjuction(PredicateBase firstPredicate, PredicateBase secondPredicate)
            : base(firstPredicate, secondPredicate)
        {
        }

        internal PredicateConjuction(IImmutableList<PredicateBase> predicates) 
            : base(predicates)
        {
        }


        internal PredicateConjuction Add(PredicateBase predicate)
        {
            Argument.NotNull(predicate, "predicate");
            var result = new PredicateConjuction(InternalPredicates.Add(predicate));
            return result;
        }

        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitPredicateConjuction(this);
        }
    }
}