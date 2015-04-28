using System;
using System.Collections.Immutable;

namespace SqlSharp2.Tree
{
    public class TableSourceList : ListNode<ITableSource>
    {
        internal static TableSourceList Empty
        {
            get { return new TableSourceList(ImmutableList<ITableSource>.Empty); }
        }


        internal TableSourceList(IImmutableList<ITableSource> items)
            : base(items)
        {
        }


        internal TableSourceList Add(ITableSource tableSource)
        {
            Argument.NotNull(tableSource, "tableSource");
            var selectList = new TableSourceList(InternalItems.Add(tableSource));
            return selectList;
        }

        internal TableSourceList ReplaceLast(ITableSource tableSource)
        {
            Argument.NotNull(tableSource, "tableSource");
            if (InternalItems.Count == 0)
            {
                throw new InvalidOperationException("Couldn't do ReplaceLast for empty list.");
            }
            var selectList = new TableSourceList(InternalItems.SetItem(InternalItems.Count - 1, tableSource));
            return selectList;
        }


        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitTableSourceList(this);
        }
    }
}
