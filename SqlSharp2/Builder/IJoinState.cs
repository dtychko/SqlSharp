namespace SqlSharp2.Builder
{
    public interface IJoinState
    {
        IJoinAsState As(string alias);
        IJoinOnState On(string condition);
    }
}