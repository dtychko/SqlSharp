using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SqlSharp2.Tree
{
    public class QueryUnion : QueryBase
    {
        public IReadOnlyList<QueryBase> Queries { get; private set; }


        internal QueryUnion(IEnumerable<QueryBase> queries)
        {
            Argument.NotNull((object)queries, "queries");
            var list = new List<QueryBase>(queries);
            Queries = new ReadOnlyCollection<QueryBase>(list);
        }


        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitQueryUnion(this);
        }
    }
}