namespace SqlSharp2.Builder.Select
{
    public class InitialStateProxy : StateProxy<IInitialState>, IInitialState
    {
        public InitialStateProxy(IInitialState state)
            : base(state)
        {
        }


        public ISelectState Select(string column)
        {
            return StateProxy.CreateFor(State.Select(column));
        }
    }
}
