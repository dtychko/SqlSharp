namespace SqlSharp2.Builder.Select
{
    public interface IJoinAsState
    {
        IJoinOnState On(string condition);
    }
}