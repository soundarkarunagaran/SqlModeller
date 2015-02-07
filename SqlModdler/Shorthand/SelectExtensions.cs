﻿using SqlModdler.Interfaces;
using SqlModdler.Model;
using SqlModdler.Model.Select;

namespace SqlModdler.Shorthand
{
    public static partial class Shorthand
    {

        public static SelectQuery Select(this SelectQuery query, Table table, string field, string fieldAlias,
            Aggregate aggregate = Aggregate.None)
        {
            query.Select(table.Alias, field, fieldAlias, aggregate);
            return query;
        }

        public static SelectQuery Select(this SelectQuery query, string tableAlias, string field, string fieldAlias,
            Aggregate aggregate = Aggregate.None)
        {
            var selectColumn = new ColumnSelector(tableAlias, field, fieldAlias, aggregate);
            query.SelectColumns.Add(selectColumn);
            return query;
        }

        public static SelectQuery Select(this SelectQuery query, string sql)
        {
            query.SelectColumns.Add(new SqlColumnSelector(sql));
            return query;
        }

        public static SelectQuery SelectAll(this SelectQuery query)
        {
            query.SelectColumns.Add(new AllColumnSelector());
            return query;
        }

        public static SelectQuery SelectRowNumber(this SelectQuery query, string alias)
        {
            query.SelectColumns.Add(new RowNumberColumnSelector(alias));
            return query;
        }


        public static SelectQuery SelectCount(this SelectQuery query, string alias)
        {
            query.SelectColumns.Add(new CountColumnSelector(alias));
            return query;
        }


        public static SelectQuery SelectTotal(this SelectQuery query, string alias, int? onlyOnRowIndex)
        {
            query.SelectColumns.Add(new TotalColumnSelector(alias, onlyOnRowIndex));
            return query;
        }


        public static SelectQuery SelectGroupKey(this SelectQuery query, string alias)
        {
            query.SelectColumns.Add(new GroupByColumnSelector(alias));
            return query;
        }

    }
}