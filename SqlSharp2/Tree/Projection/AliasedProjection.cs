namespace SqlSharp2.Tree
{
    public abstract class AliasedProjection : ProjectionBase
    {
        public string Alias { get; private set; }


        protected AliasedProjection(string alias)
        {
            Alias = alias;
        }


        protected internal abstract AliasedProjection As(string alias);
    }
}