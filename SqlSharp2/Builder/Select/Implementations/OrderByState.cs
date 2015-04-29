using System;
using System.Linq;
using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Select
{
    internal class OrderByState : SelectStatementBuilderState, IOrderByState, IOrderByInDirectionState
    {
        internal OrderByState(SelectStatement selectStatement)
            : base(selectStatement)
        {
        }


        public IOrderByState OrderBy(string column)
        {
            Argument.NotWhiteSpace(column, "column");
            var newItem = new ColumnOrder(column);
            return new OrderByState(Statement.Add(newItem));
        }

        public IOrderByInDirectionState InDirection(OrderDirection direction)
        {
            var replaceItem = Statement.Order.InternalNodes.LastOrDefault();
            if (replaceItem == null)
            {
                throw new Exception();
            }
            var replaceOrderByListItem = replaceItem as ColumnOrder;
            if (replaceOrderByListItem == null)
            {
                throw new Exception();
            }
            var newItem = new ColumnOrder(replaceOrderByListItem.Column, direction);
            return new OrderByState(Statement.Add(newItem));
        }
    }
}
