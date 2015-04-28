namespace SqlSharp2.Builder.Select
{
    internal static class StateProxy
    {
        public static InitialStateProxy CreateFor(IInitialState state)
        {
            return new InitialStateProxy(state);
        }

        public static SelectStateProxy CreateFor(ISelectState state)
        {
            return new SelectStateProxy(state);
        }

        public static SelectAsStateProxy CreateFor(ISelectAsState state)
        {
            return new SelectAsStateProxy(state);
        }

        public static FromStateProxy CreateFor(IFromState state)
        {
            return new FromStateProxy(state);
        }

        public static FromAsStateProxy CreateFor(IFromAsState state)
        {
            return new FromAsStateProxy(state);
        }

        public static JoinStateProxy CreateFor(IJoinState state)
        {
            return new JoinStateProxy(state);
        }

        public static JoinAsStateProxy CreateFor(IJoinAsState state)
        {
            return new JoinAsStateProxy(state);
        }

        public static JoinOnStateProxy CreateFor(IJoinOnState state)
        {
            return new JoinOnStateProxy(state);
        }

        public static OrderByStateProxy CreateFor(IOrderByState state)
        {
            return new OrderByStateProxy(state);
        }

        public static OrderByInDirectionStateProxy CreateFor(IOrderByInDirectionState state)
        {
            return new OrderByInDirectionStateProxy(state);
        }
    }
}
