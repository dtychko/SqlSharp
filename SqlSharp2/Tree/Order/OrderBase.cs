namespace SqlSharp2.Tree
{
    public abstract class OrderBase : TreeNode
    {
        public OrderDirection Direction { get; private set; }


        protected OrderBase(OrderDirection direction)
        {
            Direction = direction;
        }
    }
}