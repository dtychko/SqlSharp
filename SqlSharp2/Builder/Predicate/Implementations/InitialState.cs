using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Predicate
{
    internal abstract class StateBase
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

    internal abstract class PredicateStateBase : StateBase
    {
        protected Tree.Predicate Predicate { get; private set; }


        protected PredicateStateBase(Tree.Predicate predicate)
        {
            Predicate = Argument.NotNull(predicate, "predicate");
        }


        protected IAndState AndState(string expression)
        {
            return new AndState(Predicate, expression);
        }

        protected IAndNotState AndNotState(string expression)
        {
            return new AndState(Predicate, expression, true);
        }

        protected IOrState OrState(string expression)
        {
            return new OrState(Predicate, expression);
        }

        protected IOrNotState OrNotState(string expression)
        {
            return new OrState(Predicate, expression, true);
        }

        protected ITransientAndState TransientAndState()
        {
            return new TransientAndState(Predicate);
        }

        protected ITransientAndNotState TransientAndNotState()
        {
            return new TransientAndState(Predicate, true);
        }

        protected ITransientOrState TransientOrState()
        {
            return new TransientOrState(Predicate);
        }

        protected ITransientOrNotState TransientOrNotState()
        {
            return new TransientOrState(Predicate, true);
        }

        protected IPredicateConjuctionState PredicateConjuctionState(Tree.Predicate nextPredicate, bool negate = false)
        {
            if (negate)
            {
                nextPredicate = Tree.Predicate.Not(nextPredicate);
            }
            var conjuction = PredicateHelper.AppendOrCreateConjuction(Predicate, nextPredicate);
            return new PredicateConjuctionState(conjuction);
        }

        protected PredicateDisjunctionState PredicateDisjunctionState(Tree.Predicate nextPredicate, bool negate = false)
        {
            if (negate)
            {
                nextPredicate = Tree.Predicate.Not(nextPredicate);
            }
            var disjunction = PredicateHelper.AppendOrCreateDisjunction(Predicate, nextPredicate);
            return new PredicateDisjunctionState(disjunction);
        }
    }

    internal abstract class PredicateExpressionStateBase : PredicateStateBase
    {
        protected string Expression { get; private set; }


        protected PredicateExpressionStateBase(Tree.Predicate predicate, string expression)
            : base(predicate)
        {
            Expression = Argument.NotWhiteSpace(expression, "expression");
        }
    }

    internal class InitialState : StateBase, IInitialState, INotInitialState
    {
        private readonly bool _negate;


        public InitialState()
            : this(false)
        {
        }

        public InitialState(bool negate)
        {
            _negate = negate;
        }


        public IForState For(string expression)
        {
            Argument.NotWhiteSpace(expression, "expression");
            return new ForState(expression);
        }

        public INotForState Not(string expression)
        {
            Argument.NotWhiteSpace(expression, "expression");
            return new ForState(expression, true);
        }

        public INotInitialState Not()
        {
            return new InitialState(true);
        }

        public ISinglePredicateState Exists(IQuery query)
        {
            Argument.NotNull(query, "query");
            var predicate = new UnarySubQueryPredicate(query, UnarySubQueryOperationType.Exists);
            return InitialPredicateState(predicate, _negate);
        }
    }

    internal class ForState : StateBase, IForState, INotForState
    {
        private readonly string _expression;
        private readonly bool _negate;


        public ForState(string expression)
            : this(expression, false)
        {
        }

        public ForState(string expression, bool negate)
        {
            _expression = Argument.NotWhiteSpace(expression, "expression");
            _negate = negate;
        }


        public ISinglePredicateState Compare(object value, BinaryOperationType operationType)
        {
            Argument.NotNull(value, "value");
            var predicate = new BinaryPredicate(_expression, value, operationType);
            return InitialPredicateState(predicate, _negate);
        }

        public ISinglePredicateState Compare(IQuery query, BinarySubQueryOperationType operationType, SubQueryQuantifier quantifier)
        {
            Argument.NotNull(query, "query");
            var predicate = new BinarySubQueryPredicate(_expression, query, operationType, quantifier);
            return InitialPredicateState(predicate, _negate);
        }

        public ISinglePredicateState IsNull()
        {
            var predicate = new UnaryPredicate(_expression, UnaryOperationType.IsNull);
            return InitialPredicateState(predicate, _negate);
        }

        public ISinglePredicateState IsNotNull()
        {
            var predicate = new UnaryPredicate(_expression, UnaryOperationType.IsNull);
            return InitialPredicateState(predicate, _negate);
        }
    }

    internal class SinglePredicateState : PredicateStateBase, ISinglePredicateState
    {
        public SinglePredicateState(Tree.Predicate predicate)
            : base(predicate)
        {
        }


        public Tree.Predicate AsPredicate()
        {
            return Predicate;
        }

        public ITransientAndState And()
        {
            return TransientAndState();
        }

        public IAndState And(string expression)
        {
            Argument.NotWhiteSpace(expression, "expression");
            return AndState(expression);
        }

        public IPredicateConjuctionState And(Tree.Predicate predicate)
        {
            Argument.NotNull(predicate, "predicate");
            return PredicateConjuctionState(predicate);
        }

        public ITransientOrState Or()
        {
            return TransientOrState();
        }

        public IOrState Or(string expression)
        {
            Argument.NotWhiteSpace(expression, "expression");
            return OrState(expression);
        }

        public IPredicateDisjunctionState Or(Tree.Predicate predicate)
        {
            Argument.NotNull(predicate, "predicate");
            return PredicateDisjunctionState(predicate);
        }
    }

    // TODO: rename to AndExpressionState
    internal class AndState : PredicateExpressionStateBase, IAndState, IAndNotState
    {
        private readonly bool _negate;


        public AndState(Tree.Predicate predicate, string expression)
            : this(predicate, expression, false)
        {
        }

        public AndState(Tree.Predicate predicate, string expression, bool negate)
            : base(predicate, expression)
        {
            _negate = negate;
        }


        public IPredicateConjuctionState Compare(object value, BinaryOperationType operationType)
        {
            Argument.NotNull(value, "value");
            var predicate = new BinaryPredicate(Expression, value, operationType);
            return PredicateConjuctionState(predicate, _negate);
        }
        
        public IPredicateConjuctionState Compare(IQuery query, BinarySubQueryOperationType operationType, SubQueryQuantifier quantifier)
        {
            Argument.NotNull(query, "query");
            var predicate = new BinarySubQueryPredicate(Expression, query, operationType, quantifier);
            return PredicateConjuctionState(predicate, _negate);
        }

        public IPredicateConjuctionState IsNull()
        {
            var predicate = new UnaryPredicate(Expression, UnaryOperationType.IsNull);
            return PredicateConjuctionState(predicate, _negate);
        }

        public IPredicateConjuctionState IsNotNull()
        {
            var predicate = new UnaryPredicate(Expression, UnaryOperationType.IsNotNull);
            return PredicateConjuctionState(predicate, _negate);
        }
    }

    // TODO: rename to OrExpressionState
    internal class OrState : PredicateExpressionStateBase, IOrState, IOrNotState
    {
        private readonly bool _negate;


        public OrState(Tree.Predicate predicate, string expression)
            : this(predicate, expression, false)
        {
        }

        public OrState(Tree.Predicate predicate, string expression, bool negate)
            : base(predicate, expression)
        {
            _negate = negate;
        }


        public IPredicateDisjunctionState Compare(object value, BinaryOperationType operationType)
        {
            Argument.NotNull(value, "value");
            var predicate = new BinaryPredicate(Expression, value, operationType);
            return PredicateDisjunctionState(predicate, _negate);
        }

        public IPredicateDisjunctionState Compare(IQuery query, BinarySubQueryOperationType operationType,
            SubQueryQuantifier quantifier)
        {
            Argument.NotNull(query, "query");
            var predicate = new BinarySubQueryPredicate(Expression, query, operationType, quantifier);
            return PredicateDisjunctionState(predicate, _negate);
        }

        public IPredicateDisjunctionState IsNull()
        {
            var predicate = new UnaryPredicate(Expression, UnaryOperationType.IsNull);
            return PredicateDisjunctionState(predicate, _negate);
        }

        public IPredicateDisjunctionState IsNotNull()
        {
            var predicate = new UnaryPredicate(Expression, UnaryOperationType.IsNotNull);
            return PredicateDisjunctionState(predicate, _negate);
        }
    }

    internal class PredicateConjuctionState : PredicateStateBase, IPredicateConjuctionState
    {
        public PredicateConjuctionState(Tree.Predicate predicate)
            : base(predicate)
        {
        }

        public Tree.Predicate AsPredicate()
        {
            return Predicate;
        }

        public ITransientAndState And()
        {
            return TransientAndState();
        }

        public IAndState And(string expression)
        {
            Argument.NotWhiteSpace(expression, "expression");
            return AndState(expression);
        }

        public IPredicateConjuctionState And(Tree.Predicate predicate)
        {
            Argument.NotNull(predicate, "predicate");
            return PredicateConjuctionState(predicate);
        }
    }

    internal class PredicateDisjunctionState : PredicateStateBase, IPredicateDisjunctionState
    {
        public PredicateDisjunctionState(Tree.Predicate predicate)
            : base(predicate)
        {
        }


        public Tree.Predicate AsPredicate()
        {
            return Predicate;
        }

        public ITransientOrState Or()
        {
            return TransientOrState();
        }

        public IOrState Or(string expression)
        {
            Argument.NotWhiteSpace(expression, "expression");
            return OrState(expression);
        }

        public IPredicateDisjunctionState Or(Tree.Predicate predicate)
        {
            Argument.NotNull(predicate, "predicate");
            return PredicateDisjunctionState(predicate);
        }
    }

    // TODO: rename to AndState
    internal class TransientAndState : PredicateStateBase, ITransientAndState, ITransientAndNotState
    {
        private readonly bool _negate;


        public TransientAndState(Tree.Predicate predicate)
            : this(predicate, false)
        {
        }

        public TransientAndState(Tree.Predicate predicate, bool negate)
            : base(predicate)
        {
            _negate = negate;
        }


        public ITransientAndNotState Not()
        {
            return TransientAndNotState();
        }

        public IAndNotState Not(string expression)
        {
            return AndNotState(expression);
        }

        public IPredicateConjuctionState Exists(IQuery query)
        {
            Argument.NotNull(query, "query");
            var predicate = new UnarySubQueryPredicate(query, UnarySubQueryOperationType.Exists);
            return PredicateConjuctionState(predicate, _negate);
        }
    }

    // TODO: rename to OrState
    internal class TransientOrState : PredicateStateBase, ITransientOrState, ITransientOrNotState
    {
        private readonly bool _negate;


        public TransientOrState(Tree.Predicate predicate)
            : this(predicate, false)
        {
        }

        public TransientOrState(Tree.Predicate predicate, bool negate)
            : base(predicate)
        {
            _negate = negate;
        }


        public ITransientOrNotState Not()
        {
            return TransientOrNotState();
        }

        public IOrNotState Not(string expression)
        {
            return OrNotState(expression);
        }

        public IPredicateDisjunctionState Exists(IQuery query)
        {
            Argument.NotNull(query, "query");
            var predicate = new UnarySubQueryPredicate(query, UnarySubQueryOperationType.Exists);
            return PredicateDisjunctionState(predicate, _negate);
        }
    }
}
