using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;

namespace SqlSharp2.Tree
{
    public abstract class ListNode<TItem> : TreeNode
    {
        public IReadOnlyList<TItem> Items
        {
            get { return new ReadOnlyCollection<TItem>(InternalItems.ToList()); }
        }

        internal IImmutableList<TItem> InternalItems { get; private set; }


        internal ListNode(IImmutableList<TItem> items)
        {
            InternalItems = Argument.NotNull(items, "items");
        }
    }
}