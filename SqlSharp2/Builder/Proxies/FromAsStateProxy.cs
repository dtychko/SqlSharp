using SqlSharp2.Tree;

namespace SqlSharp2.Builder
{
    internal class FromAsStateProxy : QueryStateProxy<IFromAsState>, IFromAsState
    {
        public FromAsStateProxy(IFromAsState state)
            : base(state)
        {
        }


        public IFromState From(string table)
        {
            return StateProxy.CreateFor(State.From(table));
        }

        public IFromState From(IQuery subquery)
        {
            return StateProxy.CreateFor(State.From(subquery));
        }

        public IJoinState Join(string table, JoinType joinType)
        {
            return StateProxy.CreateFor(State.Join(table, joinType));
        }

        public IJoinState Join(IQuery subquery, JoinType joinType)
        {
            return StateProxy.CreateFor(State.Join(subquery, joinType));
        }
    }
}
