using SqlSharp2.Tree;

namespace SqlSharp2.Builder
{
    internal abstract class SelectStatementStateProxy<TState> : StateProxy<TState>, ISelectStatementState
        where TState : ISelectStatementState
    {
        protected SelectStatementStateProxy(TState state)
            : base(state)
        {
        }


        public SelectStatement AsStatement()
        {
            return State.AsStatement();
        }
    }
}