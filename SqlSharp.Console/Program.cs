using SqlSharp.Builder;
using SqlSharp.Expressions;
using SqlSharp2.Builder.Predicate.Implementations;

namespace SqlSharp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //var sql = new SqlSelectExpression(
            //    new SelectExpression(
            //        new SelectExpression(
            //            new SelectExpression(
            //                new SelectColumnExpression(new TermExpression("a"), new AliasExpression("C1"))),
            //                new SelectColumnExpression(new TermExpression("b"), new AliasExpression("C2"))),
            //                new SelectColumnExpression(new TermExpression("c"), new AliasExpression("C3"))),
            //    new FromExpression(
            //        new FromExpression(
            //            new FromExpression(
            //                new FromTableExpression(new TermExpression("t1"), new AliasExpression("T1"))),
            //                new FromTableExpression(new TermExpression("t2"), new AliasExpression("T2"))),
            //                new FromTableExpression(new TermExpression("t3"), new AliasExpression("T3")), new WhereExpression("C1 = C2"), JoinType.Inner),
            //                null);
            //new ConsoleExpressionVisitor().Visit(sql);

            //System.Console.WriteLine();

            var sql = Sql
                .Select("a").As("A")
                .Select("b").As("B")
                .Select("c")
                .Select("d").As("D")
                .From("table1").As("T1")
                    .InnerJoin("table2").As("T2").On("T1.Id = T2.Id")
                    .Join("table3", JoinType.LeftOuter).As("T3").On("T1.Id = T3.Id")
                .From("table4");
            var sqlExpression = sql.Expression;
            new ConsoleExpressionVisitor().Visit(sqlExpression);

            var query1 = SqlSharp2.Builder.Sql
                .Select("*")
                .From("Customers")
                .AsQuery();
            var query2 = SqlSharp2.Builder.Sql
                .Select("*")
                .From("Clients").Join("Users", SqlSharp2.Tree.JoinType.Inner).On("c_id = u_id")
                .AsQuery();

            var predicate = Predicate
                .For("id").Eq(100)
                .And("customer_id").Eq(200)
                .And().Exists(query1)
                .And().Not().Exists(query2)
                .And(Predicate
                    .For("a").Eq(123)
                    .Or("b").Eq(234)
                    .AsPredicate())
                .AsPredicate();

            System.Console.WriteLine();
        }
    }
}
