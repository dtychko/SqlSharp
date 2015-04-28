namespace SqlSharp2.Builder
{
    public interface IJoinAsState
    {
        IJoinOnState On(string condition);
    }
}