using System.Collections.Immutable;

namespace SqlSharp2.Tree
{
    public class PredicateDisjunction : PredicateJunction
    {
        internal PredicateDisjunction(PredicateBase first, PredicateBase second)
            : base(first, second)
        {
        }

        internal PredicateDisjunction(IImmutableList<PredicateBase> predicates) 
            : base(predicates)
        {
        }


        internal PredicateDisjunction Add(PredicateBase predicate)
        {
            Argument.NotNull(predicate, "predicate");
            var result = new PredicateDisjunction(InternalPredicates.Add(predicate));
            return result;
        }

        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitPredicateDisjunction(this);
        }
    }
}