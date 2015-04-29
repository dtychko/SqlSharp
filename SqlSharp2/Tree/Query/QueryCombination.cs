namespace SqlSharp2.Tree
{
    public abstract class QueryCombination : QueryBase
    {
        public QueryBase Left { get; private set; }

        public QueryBase Right { get; private set; }


        protected QueryCombination(QueryBase left, QueryBase right)
        {
            Left = Argument.NotNull(left, "left");
            Right = Argument.NotNull(right, "right");
        }
    }
}