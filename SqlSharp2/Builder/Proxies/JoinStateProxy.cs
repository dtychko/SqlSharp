namespace SqlSharp2.Builder
{
    internal class JoinStateProxy : StateProxy<IJoinState>, IJoinState
    {
        public JoinStateProxy(IJoinState state)
            : base(state)
        {
        }


        public IJoinAsState As(string alias)
        {
            return StateProxy.CreateFor(State.As(alias));
        }

        public IJoinOnState On(string condition)
        {
            return StateProxy.CreateFor(State.On(condition));
        }
    }
}