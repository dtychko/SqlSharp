namespace SqlSharp2.Builder.Predicate
{
    internal abstract class PredicateExpressionStateBase : PredicateState
    {
        protected string Expression { get; private set; }


        protected PredicateExpressionStateBase(Tree.PredicateBase predicate, string expression)
            : base(predicate)
        {
            Expression = Argument.NotWhiteSpace(expression, "expression");
        }
    }
}