namespace SqlSharp2.Tree
{
    public abstract class AliasedTableSource : TableSourceBase
    {
        public string Alias { get; private set; }


        protected AliasedTableSource(string alias)
        {
            Alias = alias;
        }


        protected internal abstract AliasedTableSource As(string alias);
    }
}