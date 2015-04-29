namespace SqlSharp2.Tree
{
    public abstract class SubQueryPredicate : PredicateBase
    {
        public QueryBase Query { get; private set; }


        internal SubQueryPredicate(QueryBase query)
        {
            Query = Argument.NotNull(query, "query");
        }
    }
}