using SqlSharp2.Tree;

namespace SqlSharp2.Builder
{
    public static class Sql
    {
        public static ISelectState Select(string column)
        {
            var query = Query.Empty.AddColumn(column);
            var initialState = (ISelectState) new SelectState(query);
            return StateProxy.CreateFor(initialState);
        }
        
        //public static IInsertState Insert() { }

        //public static IUpdateState Update() { }

        //public static IDeleteState Delete() { }
    }
}
