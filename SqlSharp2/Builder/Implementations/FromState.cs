using System;
using SqlSharp2.Tree;

namespace SqlSharp2.Builder
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
            throw new NotImplementedException();
        }

        public IFromAsState As(string alias)
        {
            Argument.NotWhiteSpace(alias, "alias");
            return new FromState(Query.AddLastTableSourceAlias(alias));
        }

        public IJoinState Join(string table, JoinType joinType)
        {
            Argument.NotWhiteSpace(table, "table");
            var joinTableSource = new TableSource(table);
            return new JoinState(Query, joinTableSource, joinType);
        }

        public IJoinState Join(IQuery subquery, JoinType joinType)
        {
            throw new NotImplementedException();
        }

        public IOrderByState OrderBy(string column)
        {
            Argument.NotWhiteSpace(column, "column");
            var newItem = new OrderListItem(column);
            var selectStatement = new SelectStatement(Query).Add(newItem);
            return new OrderByState(selectStatement);
        }
    }
}
