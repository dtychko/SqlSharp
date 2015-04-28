using SqlSharp.Expressions;

namespace SqlSharp.Builder
{
    internal abstract class FinalStateProxy<TState> : StateProxy<TState>, IFinalState
        where TState : IFinalState
    {
        public Expression Expression
        {
            get { return State.Expression; }
        }


        protected FinalStateProxy(TState state) : base(state)
        {
        }
    }
}