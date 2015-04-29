using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Select
{
    internal class JoinAsStateProxy : StateProxy<IJoinAsState>, IJoinAsState
    {
        public JoinAsStateProxy(IJoinAsState state)
            : base(state)
        {
        }


        public IJoinOnState On(PredicateBase predicate)
        {
            return StateProxy.CreateFor(State.On(predicate));
        }
    }
}