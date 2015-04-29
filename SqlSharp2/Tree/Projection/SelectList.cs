using System;
using System.Collections.Immutable;

namespace SqlSharp2.Tree
{
    public class SelectList : TreeNodeList<ProjectionBase>
    {
        internal static SelectList Empty
        {
            get { return new SelectList(ImmutableList<ProjectionBase>.Empty); }
        }


        internal SelectList(IImmutableList<ProjectionBase> projections)
            : base(projections)
        {
        }


        internal SelectList Add(ProjectionBase projection)
        {
            Argument.NotNull(projection, "projection");
            var selectList = new SelectList(InternalNodes.Add(projection));
            return selectList;
        }

        internal SelectList ReplaceLast(ProjectionBase projection)
        {
            Argument.NotNull(projection, "projection");
            if (InternalNodes.Count == 0)
            {
                throw new InvalidOperationException("Couldn't do ReplaceLast for empty list.");
            }
            var selectList = new SelectList(InternalNodes.SetItem(InternalNodes.Count - 1, projection));
            return selectList;
        }


        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitSelectList(this);
        }
    }
}
