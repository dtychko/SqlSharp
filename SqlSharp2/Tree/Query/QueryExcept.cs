namespace SqlSharp2.Tree
{
    public class QueryExcept : QueryCombination
    {
        internal QueryExcept(QueryBase left, QueryBase right)
            : base(left, right)
        {
        }


        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitQueryExcept(this);
        }
    }
}