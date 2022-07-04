using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace FINAL
{
    class additional
    {
        public static string file;

        public static DataTable Information(string location, char delimeter = ',')
        {
            DataTable result;
            location = file;

            string[] LineArray = File.ReadAllLines(location);
            result = FromDataTable(LineArray, delimeter);
            return result;
        }

        private static DataTable FromDataTable(string[] LineArray, char delimiter)
        {
            DataTable dt = new DataTable();

            AddColumnToTable(LineArray, delimiter, ref dt);
            AddRowToTable(LineArray, delimiter, ref dt);

            return dt;

        }

        private static void AddRowToTable(string[] valueCollection, char delimiter, ref DataTable dt)
        {
            for (int i = 0; i < valueCollection.Length; i++)
            {
                string[] values = valueCollection[i].Split(delimiter);
                DataRow dr = dt.NewRow();
                for (int j = 0; j < values.Length; j++)
                {
                    dr[j] = values[j];
                }
                dt.Rows.Add(dr);
            }
        }
        private static void AddColumnToTable(string[] columnCollection, char delimiter, ref DataTable dt)
        {
            string[] columns = columnCollection[0].Split(delimiter);
            foreach (string columnName in columns)
            {
                DataColumn dc = new DataColumn(columnName, typeof(string));
                dt.Columns.Add(dc);
            }

        }

    }
}