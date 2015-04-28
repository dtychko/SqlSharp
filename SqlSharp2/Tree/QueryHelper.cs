﻿using System;
using System.Linq;

namespace SqlSharp2.Tree
{
    internal static class QueryHelper
    {
        public static Query AddColumn(this Query query, string column)
        {
            Argument.NotWhiteSpace(column, "column");
            return query.Add(new SelectListItem(column));
        }

        public static Query Add(this Query query, IProjection projection)
        {
            Argument.NotNull(query, "query");
            Argument.NotNull(projection, "projection");
            return new Query(query.Select.Add(projection), query.From, query.Where);
        }

        public static Query AddTable(this Query query, string table)
        {
            Argument.NotWhiteSpace(table, "table");
            return query.Add(new TableSource(table));
        }

        public static Query Add(this Query query, ITableSource tableSource)
        {
            Argument.NotNull(query, "query");
            Argument.NotNull(tableSource, "tableSource");
            return new Query(query.Select, query.From.Add(tableSource), query.Where);
        }

        public static Query AddLastProjectionAlias(this Query query, string alias)
        {
            Argument.NotNull(query, "query");
            Argument.NotWhiteSpace(alias, "alias");
            var lastProjection = query.Select.InternalItems.LastOrDefault();
            if (lastProjection == null)
            {
                throw new InvalidOperationException("Query's select list is empty.");
            }
            var lastItem = lastProjection as SelectListItem;
            if (lastItem == null)
            {
                throw new InvalidOperationException("Unknown projection type.");
            }
            if (lastItem.Alias != null)
            {
                throw new InvalidOperationException("Last projection already has an alias.");
            }
            var newItem = new SelectListItem(lastItem.Column, alias);
            return new Query(query.Select.ReplaceLast(newItem), query.From, query.Where);
        }

        public static Query AddLastTableSourceAlias(this Query query, string alias)
        {
            Argument.NotNull(query, "query");
            Argument.NotWhiteSpace(alias, "alias");
            var lastTableSource = query.From.InternalItems.LastOrDefault();
            if (lastTableSource == null)
            {
                throw new InvalidOperationException("Query's table source list is empty.");
            }
            var lastItem = lastTableSource as TableSource;
            if (lastItem == null)
            {
                throw new InvalidOperationException("An alias couldn't be added to the last query's table source.");
            }
            if (lastItem.Alias != null)
            {
                throw new InvalidOperationException("Last table source already has an alias.");
            }
            var newTableSource = new TableSource(lastItem.Table, alias);
            return new Query(query.Select, query.From.ReplaceLast(newTableSource), query.Where);
        }

        public static Query JoinLastTableSource(this Query query, ITableSource joinTableSource, StringPredicate on, JoinType joinType)
        {
            Argument.NotNull(query, "query");
            Argument.NotNull(joinTableSource, "joinTableSource");
            var lastTableSource = query.From.InternalItems.LastOrDefault();
            if (lastTableSource == null)
            {
                throw new InvalidOperationException("Query's table source list is empty.");
            }
            var newTableSource = new JoinedTableSource(lastTableSource, joinTableSource, on, joinType);
            return new Query(query.Select, query.From.ReplaceLast(newTableSource), query.Where);
        }
    }
}