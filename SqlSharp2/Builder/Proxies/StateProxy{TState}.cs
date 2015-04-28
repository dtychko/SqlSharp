namespace SqlSharp2.Builder
{
    internal abstract class StateProxy<TState>
    {
        protected TState State { get; private set; }


        protected StateProxy(TState state)
        {
            State = state;
        }
    }
}
