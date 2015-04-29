using System.Collections.Generic;
using System.Linq;
using SqlSharp2.Builder.Select;
using SqlSharp2.Tree;

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


        public static QueryBase Union(QueryBase first, QueryBase second, params QueryBase[] other)
        {
            Argument.NotNull(first, "first");
            Argument.NotNull(second, "second");
            var queries = new List<QueryBase> { first, second };
            queries.AddRange(other.Where(q => q != null));
            return new QueryUnion(queries);
        }

        public static QueryBase Except(QueryBase left, QueryBase right)
        {
            Argument.NotNull(left, "left");
            Argument.NotNull(right, "right");
            return new QueryExcept(left, right);
        }

        public static QueryBase Intersect(QueryBase left, QueryBase right)
        {
            Argument.NotNull(left, "left");
            Argument.NotNull(right, "right");
            return new QueryIntersect(left, right);
        }
    }
}
