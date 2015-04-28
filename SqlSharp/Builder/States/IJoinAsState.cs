namespace SqlSharp.Builder
{
    public interface IJoinAsState
    {
        IJoinOnState On(string condition);
    }
}