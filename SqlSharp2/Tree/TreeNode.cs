namespace SqlSharp2.Tree
{
    public abstract class TreeNode
    {
        protected internal abstract void Accept(TreeVisitor visitor);
    }
}
