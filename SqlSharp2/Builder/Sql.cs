using SqlSharp2.Builder.Select;

namespace SqlSharp2.Builder
{
    public static class Sql
    {
        private static readonly IInitialState SelectStatementInitialState =
            new InitialStateProxy(new InitialState());


        public static ISelectState Select(string column)
        {
            return SelectStatementInitialState.Select(column);
        }
        
        //public static IInsertState Insert() { }

        //public static IUpdateState Update() { }

        //public static IDeleteState Delete() { }
    }
}
