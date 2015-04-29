using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Select
{
    internal class FromStateProxy : QueryStateProxy<IFromState>, IFromState
    {
        public FromStateProxy(IFromState state)
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

        public IFromAsState As(string alias)
        {
            return StateProxy.CreateFor(State.As(alias));
        }

        public IJoinState Join(string table, JoinType joinType)
        {
            return StateProxy.CreateFor(State.Join(table, joinType));
        }

        public IJoinState Join(QueryBase subquery, JoinType joinType)
        {
            return StateProxy.CreateFor(State.Join(subquery, joinType));
        }

        public IOrderByState OrderBy(string column)
        {
            return StateProxy.CreateFor(State.OrderBy(column));
        }
    }
}
