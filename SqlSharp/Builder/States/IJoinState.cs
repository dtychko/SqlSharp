namespace SqlSharp.Builder
{
    public interface IJoinState
    {
        IJoinAsState As(string alias);
        IJoinOnState On(string condition);
    }
}