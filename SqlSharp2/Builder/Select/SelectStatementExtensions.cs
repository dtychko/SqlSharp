using SqlSharp2.Tree;

namespace SqlSharp2.Builder.Select
{
    public static class SelectStatementExtensions
    {
        public static IJoinState InnerJoin(this IFromState state, string table)
        {
            Argument.NotNull(state, "state");
            return state.Join(table, JoinType.Inner);
        }

        public static IJoinState InnerJoin(this IFromAsState state, string table)
        {
            Argument.NotNull(state, "state");
            return state.Join(table, JoinType.Inner);
        }

        public static IJoinState LeftOuterJoin(this IFromState state, string table)
        {
            Argument.NotNull(state, "state");
            return state.Join(table, JoinType.LeftOuter);
        }

        public static IJoinState LeftOuterJoin(this IFromAsState state, string table)
        {
            Argument.NotNull(state, "state");
            return state.Join(table, JoinType.LeftOuter);
        }

        public static IJoinState RightOuterJoin(this IFromState state, string table)
        {
            Argument.NotNull(state, "state");
            return state.Join(table, JoinType.RightOuter);
        }

        public static IJoinState RightOuterJoin(this IFromAsState state, string table)
        {
            Argument.NotNull(state, "state");
            return state.Join(table, JoinType.RightOuter);
        }

        public static IJoinState FullOuterJoin(this IFromState state, string table)
        {
            Argument.NotNull(state, "state");
            return state.Join(table, JoinType.FullOuter);
        }

        public static IJoinState FullOuterJoin(this IFromAsState state, string table)
        {
            Argument.NotNull(state, "state");
            return state.Join(table, JoinType.FullOuter);
        }
    }
}
