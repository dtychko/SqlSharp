using SqlSharp2.Tree;

namespace SqlSharp2.Builder
{
    internal class JoinState : QueryState, IJoinState, IJoinAsState
    {
        private readonly TableSource _joinTableSource;
        private readonly JoinType _joinType;
        

        internal JoinState(Query query, TableSource joinTableSource, JoinType joinType)
            : base(query)
        {
            _joinTableSource = Argument.NotNull(joinTableSource, "joinTableSource");
            _joinType = joinType;
        }


        public IJoinAsState As(string alias)
        {
            Argument.NotWhiteSpace(alias, "alias");
            var joinTableSource = new TableSource(_joinTableSource.Table, alias);
            return new JoinState(Query, joinTableSource, _joinType);
        }

        public IJoinOnState On(string predicate)
        {
            Argument.NotWhiteSpace(predicate, "predicate");
            var on = new StringPredicate(predicate);
            return new FromState(Query.JoinLastTableSource(_joinTableSource, on, _joinType));
        }
    }
}
