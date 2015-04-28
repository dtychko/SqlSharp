using System.Linq;

namespace SqlSharp2.Tree
{
    public abstract class TreeVisitor
    {
        public virtual void Visit(TreeNode node)
        {
            Argument.NotNull(node, "node");
            node.Accept(this);
        }


        protected internal virtual void VisitSelectStatement(SelectStatement statement)
        {
            Visit(statement.Query);
            Visit(statement.Order);
        }

        protected internal virtual void VisitQuery(Query query)
        {
            Visit(query.Select);
            Visit(query.From);
            Visit(query.Where);
        }

        protected internal virtual void VisitSelectList(SelectList list)
        {
            foreach (var item in list.Items.OfType<TreeNode>())
            {
                Visit(item);
            }
        }

        protected internal virtual void VisitSelectListItem(SelectListItem item)
        {
        }

        protected internal virtual void VisitTableSourceList(TableSourceList list)
        {
            foreach (var item in list.Items.OfType<TreeNode>())
            {
                Visit(item);
            }
        }

        protected internal virtual void VisitTableSource(TableSource tableSource)
        {
        }

        protected internal virtual void VisitSubQueryTableSource(SubQueryTableSource tableSource)
        {
            Visit((TreeNode)tableSource.Query);
        }

        protected internal virtual void VisitJoinedTableSource(JoinedTableSource tableSource)
        {
            Visit((TreeNode)tableSource.Left);
            Visit((TreeNode)tableSource.Right);
            Visit(tableSource.On);
        }

        protected internal virtual void VisitPredicate(StringPredicate predicate)
        {
        }

        protected internal virtual void VisitOrderByList(OrderList list)
        {
            foreach (var item in list.Items.OfType<TreeNode>())
            {
                Visit(item);
            }
        }

        protected internal virtual void VisitOrderByListItem(OrderListItem item)
        {
        }


        protected internal virtual void VisitPredicateConjuction(PredicateConjuction conjuction)
        {
            foreach (var predicate in conjuction.Predicates)
            {
                Visit(predicate);
            }
        }

        protected internal virtual void VisitPredicateDisjunction(PredicateDisjunction disjunction)
        {
            foreach (var predicate in disjunction.Predicates)
            {
                Visit(predicate);
            }
        }

        protected internal virtual void VisitNotPredicate(NotPredicate predicate)
        {
            Visit(predicate.Predicate);
        }

        protected internal virtual void VisitBinaryPredicate(BinaryPredicate predicate)
        {
        }

        protected internal virtual void VisitUnaryPredicate(UnaryPredicate predicate)
        {
        }

        protected internal virtual void VisitBetweenPredicate(BetweenPredicate predicate)
        {
        }

        protected internal virtual void VisitInPredicate(InPredicate predicate)
        {
        }

        protected internal virtual void VisitInSubQueryPredicate(InSubQueryPredicate predicate)
        {
        }

        protected internal virtual void VisitBinarySubQueryPredicate(BinarySubQueryPredicate predicate)
        {
        }

        protected internal virtual void VisitUnarySubQueryPredicate(UnarySubQueryPredicate predicate)
        {
        }
    }
}
