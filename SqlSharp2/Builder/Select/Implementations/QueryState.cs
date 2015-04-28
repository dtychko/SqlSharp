using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Select
{
    internal abstract class QueryState : State, IQueryState
    {
        protected Query Query { get; private set; }


        protected QueryState(Query query)
        {
            Query = Argument.NotNull(query, "query");
        }


        public Query AsQuery()
        {
            return Query;
        }
    }
}