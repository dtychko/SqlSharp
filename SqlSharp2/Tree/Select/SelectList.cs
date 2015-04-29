using System;
using System.Collections.Immutable;

namespace SqlSharp2.Tree
{
    public class SelectList : ListNode<ProjectionBase>
    {
        internal static SelectList Empty
        {
            get { return new SelectList(ImmutableList<ProjectionBase>.Empty); }
        }


        internal SelectList(IImmutableList<ProjectionBase> items)
            : base(items)
        {
        }


        internal SelectList Add(ProjectionBase projection)
        {
            Argument.NotNull(projection, "projection");
            var selectList = new SelectList(InternalItems.Add(projection));
            return selectList;
        }

        internal SelectList ReplaceLast(ProjectionBase projection)
        {
            Argument.NotNull(projection, "projection");
            if (InternalItems.Count == 0)
            {
                throw new InvalidOperationException("Couldn't do ReplaceLast for empty list.");
            }
            var selectList = new SelectList(InternalItems.SetItem(InternalItems.Count - 1, projection));
            return selectList;
        }


        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitSelectList(this);
        }
    }
}
