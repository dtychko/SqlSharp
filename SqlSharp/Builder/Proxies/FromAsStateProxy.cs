using SqlSharp.Expressions;

namespace SqlSharp.Builder
{
    internal class FromAsStateProxy : FinalStateProxy<IFromAsState>, IFromAsState
    {
        public FromAsStateProxy(IFromAsState state)
            : base(state)
        {
        }


        public IFromState From(string table)
        {
            return StateProxy.CreateFor(State.From(table));
        }

        public IJoinState Join(string table, JoinType joinType)
        {
            return StateProxy.CreateFor(State.Join(table, joinType));
        }
    }
}
