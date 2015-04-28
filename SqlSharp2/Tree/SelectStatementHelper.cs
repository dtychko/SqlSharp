namespace SqlSharp2.Tree
{
    internal static class SelectStatementHelper
    {
        public static SelectStatement Add(this SelectStatement statement, IOrderListItem item)
        {
            Argument.NotNull(statement, "statement");
            Argument.NotNull(item, "item");
            return new SelectStatement(statement.Query, statement.Order.Add(item));
        }
    }
}