using System;
using System.Linq;
using SqlSharp2.Tree;

namespace SqlSharp2.Builder
{
    internal class OrderByState : SelectStatementState, IOrderByState, IOrderByInDirectionState
    {
        internal OrderByState(SelectStatement selectStatement)
            : base(selectStatement)
        {
        }


        public IOrderByState OrderBy(string column)
        {
            Argument.NotWhiteSpace(column, "column");
            var newItem = new OrderListItem(column);
            return new OrderByState(Statement.Add(newItem));
        }

        public IOrderByInDirectionState InDirection(OrderDirection direction)
        {
            var replaceItem = Statement.Order.InternalItems.LastOrDefault();
            if (replaceItem == null)
            {
                throw new Exception();
            }
            var replaceOrderByListItem = replaceItem as OrderListItem;
            if (replaceOrderByListItem == null)
            {
                throw new Exception();
            }
            var newItem = new OrderListItem(replaceOrderByListItem.Column, direction);
            return new OrderByState(Statement.Add(newItem));
        }
    }
}
