﻿using SqlSharp2.Tree;

namespace SqlSharp2.Builder
{
    internal class SelectAsStateProxy : StateProxy<ISelectAsState>, ISelectAsState
    {
        public SelectAsStateProxy(ISelectAsState state)
            : base(state)
        {
        }


        public ISelectState Select(string column)
        {
            return StateProxy.CreateFor(State.Select(column));
        }

        public IFromState From(string table)
        {
            return StateProxy.CreateFor(State.From(table));
        }

        public IFromState From(IQuery subquery)
        {
            return StateProxy.CreateFor(State.From(subquery));
        }
    }
}
