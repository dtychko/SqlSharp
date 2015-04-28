using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;

namespace SqlSharp2.Tree
{
    public abstract class PredicateJunction : Predicate
    {
        public IReadOnlyList<Predicate> Predicates
        {
            get { return new ReadOnlyCollection<Predicate>(InternalPredicates.ToList());}
        }

        internal IImmutableList<Predicate> InternalPredicates { get; private set; }


        internal PredicateJunction(IImmutableList<Predicate> predicates)
        {
            InternalPredicates = Argument.NotNull(predicates, "predicates");
        }
    }
}