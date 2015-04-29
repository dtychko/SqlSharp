using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Select
{
    internal class SelectState : QueryState, ISelectState, ISelectAsState
    {
        internal SelectState(Query query)
            : base(query)
        {
        }


        public ISelectState Select(string column)
        {
            Argument.NotWhiteSpace(column, "column");
            return new SelectState(Query.AddColumn(column));
        }

        public ISelectAsState As(string alias)
        {
            Argument.NotWhiteSpace(alias, "alias");
            return new SelectState(Query.AddLastProjectionAlias(alias));
        }

        public IFromState From(string table)
        {
            Argument.NotWhiteSpace(table, "table");
            return new FromState(Query.AddTable(table));
        }

        public IFromState From(QueryBase subquery)
        {
            throw new System.NotImplementedException();
        }
    }
}
