using SqlSharp2.Builder;
using SqlSharp2.Builder.Predicate;
using SqlSharp2.Builder.Select;

namespace SqlSharp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var query1 = Sql
                .Select("user_id").As("id")
                .Select("user_name").As("name")
                .Select("age")
                .From("users").As("u")
                    .InnerJoin("profiles").As("p").On(
                        Predicate.For("u.user_id").Eq("p.user_id").AsPredicate())
                .AsQuery();
            var query2 = Sql
                .Select("customer_id").As("id")
                .Select("customer_name").As("name")
                .Select("0").As("age")
                .From("customers")
                .AsQuery();
            var query3 = Sql.Except(Sql.Union(query1, query2), query1);

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
