using System.Collections.Immutable;

namespace SqlSharp2.Tree
{
    public class PredicateConjuction : PredicateJunction
    {
        internal static PredicateConjuction Empty
        {
            get { return new PredicateConjuction(ImmutableList<Predicate>.Empty); }
        }


        internal PredicateConjuction(IImmutableList<Predicate> predicates) 
            : base(predicates)
        {
        }


        internal PredicateConjuction Add(Predicate predicate)
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