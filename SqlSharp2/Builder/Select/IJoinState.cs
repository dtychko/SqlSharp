namespace SqlSharp2.Builder.Select
{
    public interface IJoinState
    {
        IJoinAsState As(string alias);
        IJoinOnState On(string condition);
    }
}