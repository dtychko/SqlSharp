using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Predicate
{
    internal abstract class PredicateState : State
    {
        protected Tree.PredicateBase Predicate { get; private set; }


        protected PredicateState(Tree.PredicateBase predicate)
        {
            Predicate = Argument.NotNull(predicate, "predicate");
        }


        protected IAndExpressionState AndState(string expression)
        {
            return new AndExpressionState(Predicate, expression);
        }

        protected IAndNotExpressionState AndNotState(string expression)
        {
            return new AndExpressionState(Predicate, expression, true);
        }

        protected IOrExpressionState OrState(string expression)
        {
            return new OrExpressionState(Predicate, expression);
        }

        protected IOrNotExpressionState OrNotState(string expression)
        {
            return new OrExpressionState(Predicate, expression, true);
        }

        protected IAndState TransientAndState()
        {
            return new AndState(Predicate);
        }

        protected IAndNotState TransientAndNotState()
        {
            return new AndState(Predicate, true);
        }

        protected IOrState TransientOrState()
        {
            return new OrState(Predicate);
        }

        protected IOrNotState TransientOrNotState()
        {
            return new OrState(Predicate, true);
        }

        protected IPredicateConjuctionState PredicateConjuctionState(Tree.PredicateBase nextPredicate, bool negate = false)
        {
            if (negate)
            {
                nextPredicate = Builder.Predicate.Predicate.Not(nextPredicate);
            }
            var conjuction = PredicateHelper.AppendOrCreateConjuction(Predicate, nextPredicate);
            return new PredicateConjuctionState(conjuction);
        }

        protected PredicateDisjunctionState PredicateDisjunctionState(Tree.PredicateBase nextPredicate, bool negate = false)
        {
            if (negate)
            {
                nextPredicate = Builder.Predicate.Predicate.Not(nextPredicate);
            }
            var disjunction = PredicateHelper.AppendOrCreateDisjunction(Predicate, nextPredicate);
            return new PredicateDisjunctionState(disjunction);
        }
    }
}