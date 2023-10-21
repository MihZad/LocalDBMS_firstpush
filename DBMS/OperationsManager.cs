using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalDBMS
{
    internal static class OperationsManager
    {
        internal static DataTable performFullMultiplication(DataTable table1, DataTable table2)
        {
            var columns = new List<DataColumn>();

            for (int i = 0; i < table1.Columns.Count; i++)
                columns.Add(table1.Columns[i]);
            for(int j = 0; j < table2.Columns.Count; j++)
                columns.Add(table2.Columns[j]);

            DataTable dt = new DataTable("result", columns, new DataBase());
            foreach(var r1 in table1.Rows)
                foreach(var r2 in table2.Rows)
                {
                    var data = new List<SupportedType>();
                    foreach(var d1 in r1.Data) data.Add(d1);
                    foreach(var d2 in r2.Data) data.Add(d2);
                    dt.AddRow(data);
                }
            return dt;
        }
    }
}
