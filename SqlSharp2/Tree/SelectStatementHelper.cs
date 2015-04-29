namespace SqlSharp2.Tree
{
    internal static class SelectStatementHelper
    {
        public static SelectStatement Add(this SelectStatement statement, OrderBase order)
        {
            Argument.NotNull(statement, "statement");
            Argument.NotNull(order, "order");
            return new SelectStatement(statement.Query, statement.Order.Add(order));
        }
    }
}