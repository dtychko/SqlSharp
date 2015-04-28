using System;
using System.Collections.Immutable;

namespace SqlSharp2.Tree
{
    public class OrderList : ListNode<IOrderListItem>
    {
        internal static OrderList Empty
        {
            get { return new OrderList(ImmutableList<IOrderListItem>.Empty); }
        }


        internal OrderList(IImmutableList<IOrderListItem> items)
            : base(items)
        {
        }


        internal OrderList Add(IOrderListItem item)
        {
            Argument.NotNull(item, "item");
            var selectList = new OrderList(InternalItems.Add(item));
            return selectList;
        }

        internal OrderList ReplaceLast(IOrderListItem item)
        {
            Argument.NotNull(item, "item");
            if (InternalItems.Count == 0)
            {
                throw new InvalidOperationException("List is empty.");
            }
            var selectList = new OrderList(InternalItems.SetItem(InternalItems.Count - 1, item));
            return selectList;
        }


        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitOrderByList(this);
        }
    }
}
