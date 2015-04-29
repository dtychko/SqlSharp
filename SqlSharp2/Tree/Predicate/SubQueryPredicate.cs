namespace SqlSharp2.Tree
{
    public abstract class SubQueryPredicate : PredicateBase
    {
        public IQuery Query { get; private set; }


        internal SubQueryPredicate(IQuery query)
        {
            Query = Argument.NotNull(query, "query");
        }
    }
}