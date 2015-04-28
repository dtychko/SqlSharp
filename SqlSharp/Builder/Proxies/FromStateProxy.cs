using SqlSharp.Expressions;

namespace SqlSharp.Builder
{
    internal class FromStateProxy : FinalStateProxy<IFromState>, IFromState
    {
        public FromStateProxy(IFromState state)
            : base(state)
        {
        }


        public IFromState From(string table)
        {
            return StateProxy.CreateFor(State.From(table));
        }

        public IFromAsState As(string alias)
        {
            return StateProxy.CreateFor(State.As(alias));
        }

        public IJoinState Join(string table, JoinType joinType)
        {
            return StateProxy.CreateFor(State.Join(table, joinType));
        }
    }
}
