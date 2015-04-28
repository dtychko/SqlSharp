using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Select
{
    internal abstract class SelectStatementStateProxy<TState> : StateProxy<TState>, ISelectStatementBuilder
        where TState : ISelectStatementBuilder
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