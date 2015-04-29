using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Select
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

        public IFromState From(QueryBase subquery)
        {
            return StateProxy.CreateFor(State.From(subquery));
        }

        public IJoinState Join(string table, JoinType joinType)
        {
            return StateProxy.CreateFor(State.Join(table, joinType));
        }

        public IJoinState Join(QueryBase subquery, JoinType joinType)
        {
            return StateProxy.CreateFor(State.Join(subquery, joinType));
        }
    }
}
