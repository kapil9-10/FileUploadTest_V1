using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace helperMethods
{
    public class Utils
    {
        public static DataTable ConvertListToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in Props)
                dataTable.Columns.Add(prop.Name);

            foreach (T item in items)
            {
                var values = new object[Props.Length - 1 + 1 - 1 + 1];

                for (int i = 0; i <= Props.Length - 1; i++)
                {
                    if (Props[i].PropertyType == typeof(string))
                        values[i] = Props[i].GetValue(item, null);
                    else if (Props[i].PropertyType == typeof(bool))
                        values[i] = Props[i].GetValue(item, null);
                    else
                        values[i] = string.Join<string>(",", (List<string>)Props[i].GetValue(item, null));
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }
}
