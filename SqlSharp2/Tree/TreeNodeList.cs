using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;

namespace SqlSharp2.Tree
{
    public abstract class TreeNodeList<TNode> : TreeNode
    {
        public IReadOnlyList<TNode> Nodes
        {
            get { return new ReadOnlyCollection<TNode>(InternalNodes.ToList()); }
        }

        internal IImmutableList<TNode> InternalNodes { get; private set; }


        internal TreeNodeList(IImmutableList<TNode> nodes)
        {
            InternalNodes = Argument.NotNull(nodes, "items");
        }
    }
}