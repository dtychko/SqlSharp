using SqlSharp.Expressions;

namespace SqlSharp.Builder
{
    public static class Sql
    {
        public static ISelectState Select(string column)
        {
            var selectExpression = new ColumnNameExpression(column);
            var initialState = (ISelectState) new SelectState(selectExpression);
            return StateProxy.CreateFor(initialState);
        }

        //public static IInsertState Insert() { }

        //public static IUpdateState Update() { }

        //public static IDeleteState Delete() { }
    }
}
