using System;
using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Select
{
    internal class FromState : QueryState, IFromState, IFromAsState, IJoinOnState
    {
        internal FromState(Query query)
            : base(query)
        {
        }


        public IFromState From(string table)
        {
            Argument.NotWhiteSpace(table, "table");
            return new FromState(Query.AddTable(table));
        }

        public IFromState From(IQuery subquery)
        {
            Argument.NotNull(subquery, "subquery");
            return new FromState(Query.AddTable(subquery));
        }

        public IFromAsState As(string alias)
        {
            Argument.NotWhiteSpace(alias, "alias");
            return new FromState(Query.AddLastTableSourceAlias(alias));
        }

        public IJoinState Join(string table, JoinType joinType)
        {
            Argument.NotWhiteSpace(table, "table");
            var joinTableSource = new SimpleTableSource(table);
            return new JoinState(Query, joinTableSource, joinType);
        }

        public IJoinState Join(IQuery subquery, JoinType joinType)
        {
            Argument.NotNull(subquery, "subquery");
            var joinTableSource = new SubQueryTableSource(subquery);
            return new JoinState(Query, joinTableSource, joinType);
        }

        public IOrderByState OrderBy(string column)
        {
            Argument.NotWhiteSpace(column, "column");
            var newItem = new ColumnOrder(column);
            var selectStatement = new SelectStatement(Query).Add(newItem);
            return new OrderByState(selectStatement);
        }
    }
}
