using SqlSharp.Expressions;

namespace SqlSharp.Builder
{
    public static class StateExtensions
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
    }
}
