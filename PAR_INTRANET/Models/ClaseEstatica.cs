using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace PAR_INTRANET.Models
{
    public static class ClaseEstatica
    {
        public static DataTable ToPivotTable<T, TColumn, TRow, TData>(
                                                                        this IEnumerable<T> source,
                                                                        Func<T, TColumn> columnSelector,
                                                                        Expression<Func<T, TRow>> rowSelector,
                                                                        Func<IEnumerable<T>, TData> dataSelector
                                                                     )
        {
            DataTable table = new DataTable();
            var rowName = ((MemberExpression)rowSelector.Body).Member.Name;
            table.Columns.Add(new DataColumn(rowName));
            var columns = source.Select(columnSelector).Distinct();

            foreach (var column in columns)
                table.Columns.Add(new DataColumn(column.ToString()));

            var rows = source.GroupBy(rowSelector.Compile())
                             .Select(rowGroup => new
                             {
                                 Key = rowGroup.Key,
                                 Values = columns.GroupJoin(
                                     rowGroup,
                                     c => c,
                                     r => columnSelector(r),
                                     (c, columnGroup) => dataSelector(columnGroup))
                             });

            foreach (var row in rows)
            {
                var dataRow = table.NewRow();
                var items = row.Values.Cast<object>().ToList();
                items.Insert(0, row.Key);
                dataRow.ItemArray = items.ToArray();
                table.Rows.Add(dataRow);
            }

            return table;
        }

        public static DataTable ToPivotTableMultiple<T, TColumn, TRow, TData>(
         this IEnumerable<T> source,
         Func<T, TColumn> columnSelector,
         Expression<Func<T, TRow>> rowSelector,
         Func<IEnumerable<T>, TData> dataSelector)
        {
            DataTable table = new DataTable();
            var rowsName = ((NewExpression)rowSelector.Body).Members.Select(s => s).ToList();
            foreach (var row in rowsName)
            {
                var name = row.Name;
                table.Columns.Add(new DataColumn(name));
            }
            var columns = source.Select(columnSelector).Distinct();
            foreach (var column in columns)
                table.Columns.Add(new DataColumn(column.ToString()));
            var rows = source.GroupBy(rowSelector.Compile())
                             .Select(rowGroup => new
                             {
                                 Key = rowGroup.Key,
                                 Values = columns.GroupJoin(
                                     rowGroup,
                                     c => c,
                                     r => columnSelector(r),
                                     (c, columnGroup) => dataSelector(columnGroup))
                             });

            foreach (var row in rows)
            {
                var dataRow = table.NewRow();
                var items = row.Values.Cast<object>().ToList();
                string[] keyRow = row.Key.ToString().Split(',');
                int index = 0;
                foreach (var key in keyRow)
                {
                    string keyValue = key.Replace("}", "").Split('=')[1].Trim();
                    items.Insert(index, keyValue);
                    index++;
                }
                dataRow.ItemArray = items.ToArray();
                table.Rows.Add(dataRow);
            }
            return table;
        }
    }
}