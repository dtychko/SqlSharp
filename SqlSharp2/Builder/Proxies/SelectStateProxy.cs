using SqlSharp2.Tree;

namespace SqlSharp2.Builder
{
    internal class SelectStateProxy : StateProxy<ISelectState>, ISelectState
    {
        public SelectStateProxy(ISelectState state)
            : base(state)
        {
        }


        public ISelectState Select(string column)
        {
            return StateProxy.CreateFor(State.Select(column));
        }

        public ISelectAsState As(string alias)
        {
            return StateProxy.CreateFor(State.As(alias));
        }

        public IFromState From(string table)
        {
            return StateProxy.CreateFor(State.From(table));
        }

        public IFromState From(IQuery subquery)
        {
            return StateProxy.CreateFor(State.From(subquery));
        }
    }
}
