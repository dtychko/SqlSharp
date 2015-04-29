namespace SqlSharp2.Tree
{
    public class QueryIntersect : QueryCombination
    {
        internal QueryIntersect(QueryBase left, QueryBase right)
            : base(left, right)
        {
        }


        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitQueryIntersect(this);
        }
    }
}