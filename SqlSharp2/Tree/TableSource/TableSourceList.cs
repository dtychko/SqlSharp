using System;
using System.Collections.Immutable;

namespace SqlSharp2.Tree
{
    public class TableSourceList : TreeNodeList<TableSourceBase>
    {
        internal static TableSourceList Empty
        {
            get { return new TableSourceList(ImmutableList<TableSourceBase>.Empty); }
        }


        internal TableSourceList(IImmutableList<TableSourceBase> items)
            : base(items)
        {
        }


        internal TableSourceList Add(TableSourceBase tableSource)
        {
            Argument.NotNull(tableSource, "tableSource");
            var selectList = new TableSourceList(InternalNodes.Add(tableSource));
            return selectList;
        }

        internal TableSourceList ReplaceLast(TableSourceBase tableSource)
        {
            Argument.NotNull(tableSource, "tableSource");
            if (InternalNodes.Count == 0)
            {
                throw new InvalidOperationException("Couldn't do ReplaceLast for empty list.");
            }
            var selectList = new TableSourceList(InternalNodes.SetItem(InternalNodes.Count - 1, tableSource));
            return selectList;
        }


        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitTableSourceList(this);
        }
    }
}
