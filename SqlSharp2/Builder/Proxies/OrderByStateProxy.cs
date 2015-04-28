using SqlSharp2.Tree;

namespace SqlSharp2.Builder
{
    internal class OrderByStateProxy : SelectStatementStateProxy<IOrderByState>, IOrderByState
    {
        public OrderByStateProxy(IOrderByState state)
            : base(state)
        {
        }


        public IOrderByState OrderBy(string column)
        {
            return StateProxy.CreateFor(State.OrderBy(column));
        }

        public IOrderByInDirectionState InDirection(OrderDirection direction)
        {
            return StateProxy.CreateFor(State.InDirection(direction));
        }
    }
}