namespace SqlSharp.Builder
{
    internal class SelectAsStateProxy : StateProxy<ISelectAsState>, ISelectAsState
    {
        public SelectAsStateProxy(ISelectAsState state)
            : base(state)
        {
        }


        public ISelectState Select(string column)
        {
            return StateProxy.CreateFor(State.Select(column));
        }

        public IFromState From(string table)
        {
            return StateProxy.CreateFor(State.From(table));
        }
    }
}
