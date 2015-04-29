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

        protected internal virtual void VisitQueryUnion(QueryUnion union)
        {
            foreach (var query in union.Queries)
            {
                Visit(query);
            }
        }

        protected internal virtual void VisitQueryExcept(QueryExcept except)
        {
            Visit(except.Left);
            Visit(except.Right);
        }

        protected internal virtual void VisitQueryIntersect(QueryIntersect intersect)
        {
            Visit(intersect.Left);
            Visit(intersect.Right);
        }

        protected internal virtual void VisitSelectList(SelectList list)
        {
            foreach (var item in list.Nodes)
            {
                Visit(item);
            }
        }

        protected internal virtual void VisitColumnProjection(ColumnProjection item)
        {
        }

        protected internal virtual void VisitTableSourceList(TableSourceList list)
        {
            foreach (var item in list.Nodes)
            {
                Visit(item);
            }
        }

        protected internal virtual void VisitSimpleTableSource(SimpleTableSource tableSource)
        {
        }

        protected internal virtual void VisitSubQueryTableSource(SubQueryTableSource tableSource)
        {
            Visit(tableSource.Query);
        }

        protected internal virtual void VisitJoinedTableSource(JoinedTableSource tableSource)
        {
            Visit(tableSource.Left);
            Visit(tableSource.Right);
            Visit(tableSource.On);
        }

        protected internal virtual void VisitOrderList(OrderList list)
        {
            foreach (var item in list.Nodes)
            {
                Visit(item);
            }
        }

        protected internal virtual void VisitColumnOrder(ColumnOrder item)
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
