using System;
using System.Collections.Immutable;

namespace SqlSharp2.Tree
{
    public class OrderList : TreeNodeList<OrderBase>
    {
        internal static OrderList Empty
        {
            get { return new OrderList(ImmutableList<OrderBase>.Empty); }
        }


        internal OrderList(IImmutableList<OrderBase> orders)
            : base(orders)
        {
        }


        internal OrderList Add(OrderBase order)
        {
            Argument.NotNull(order, "order");
            var selectList = new OrderList(InternalNodes.Add(order));
            return selectList;
        }

        internal OrderList ReplaceLast(OrderBase order)
        {
            Argument.NotNull(order, "order");
            if (InternalNodes.Count == 0)
            {
                throw new InvalidOperationException("List is empty.");
            }
            var selectList = new OrderList(InternalNodes.SetItem(InternalNodes.Count - 1, order));
            return selectList;
        }


        protected internal override void Accept(TreeVisitor visitor)
        {
            visitor.VisitOrderList(this);
        }
    }
}
