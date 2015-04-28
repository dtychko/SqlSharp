using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Select
{
    internal abstract class QueryStateProxy<TState> : StateProxy<TState>, IQueryState
        where TState : IQueryState
    {
        protected QueryStateProxy(TState state)
            : base(state)
        {
        }


        public Query AsQuery()
        {
            return State.AsQuery();
        }
    }
}