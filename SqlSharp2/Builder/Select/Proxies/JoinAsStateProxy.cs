namespace SqlSharp2.Builder.Select
{
    internal class JoinAsStateProxy : StateProxy<IJoinAsState>, IJoinAsState
    {
        public JoinAsStateProxy(IJoinAsState state)
            : base(state)
        {
        }


        public IJoinOnState On(string condition)
        {
            return StateProxy.CreateFor(State.On(condition));
        }
    }
}