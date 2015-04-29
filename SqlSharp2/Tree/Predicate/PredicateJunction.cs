using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;

namespace SqlSharp2.Tree
{
    public abstract class PredicateJunction : PredicateBase
    {
        public IReadOnlyList<PredicateBase> Predicates
        {
            get { return new ReadOnlyCollection<PredicateBase>(InternalPredicates.ToList());}
        }

        internal IImmutableList<PredicateBase> InternalPredicates { get; private set; }


        internal PredicateJunction(PredicateBase first, PredicateBase second)
        {
            Argument.NotNull(first, "first");
            Argument.NotNull(second, "second");
            InternalPredicates = ImmutableList<PredicateBase>.Empty.Add(first).Add(second);
        }

        internal PredicateJunction(IImmutableList<PredicateBase> predicates)
        {
            InternalPredicates = Argument.NotNull(predicates, "predicates");
        }
    }
}