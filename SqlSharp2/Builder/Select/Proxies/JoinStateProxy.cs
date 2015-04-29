using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Select
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

        public IJoinOnState On(PredicateBase predicate)
        {
            return StateProxy.CreateFor(State.On(predicate));
        }
    }
}