﻿namespace SqlSharp2.Builder
{
    internal class OrderByInDirectionStateProxy : SelectStatementStateProxy<IOrderByInDirectionState>, IOrderByInDirectionState
    {
        public OrderByInDirectionStateProxy(IOrderByInDirectionState state)
            : base(state)
        {
        }


        public IOrderByState OrderBy(string column)
        {
            return StateProxy.CreateFor(State.OrderBy(column));
        }
    }
}