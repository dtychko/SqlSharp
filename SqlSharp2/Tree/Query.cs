﻿namespace SqlSharp2.Tree
{
    public class Query : TreeNode, IQuery
    {
        internal static Query Empty
        {
            get { return new Query(SelectList.Empty, TableSourceList.Empty, null);}
        }


        public SelectList Select { get; private set; }

        public TableSourceList From { get; private set; }

        public StringPredicate Where { get; private set; }


        internal Query(SelectList select, TableSourceList from, StringPredicate where)
        {
            Select = Argument.NotNull(select, "select");
            From = Argument.NotNull(from, "from");
            Where = where;
        }


        public static implicit operator SelectStatement(Query query)
        {
            return new SelectStatement(query);
        }


        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitQuery(this);
        }
    }
}
