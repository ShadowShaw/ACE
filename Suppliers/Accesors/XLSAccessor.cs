using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using Suppliers.Interfaces;

namespace Suppliers.Accesors
{
    public class XLSAccessor : IAccessor
    {
        public IEnumerable<T> Load<T>(string filename) where T : class, new()
        {
            IEnumerable<T> result = null;
            ConvertExcelToCsv(filename);
            return result;
        }

        static void ConvertExcelToCsv(string excelFilePath, int worksheetNumber = 1)
        {
            if (!File.Exists(excelFilePath))
            {
                throw new FileNotFoundException(excelFilePath);
            }

            // connection string
            string connectioString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;IMEX=1;HDR=NO\"", excelFilePath);
            OleDbConnection connection = new OleDbConnection(connectioString);

            // get schema, then data
            DataTable dataTable = new DataTable();
            try
            {
                connection.Open();
                DataTable schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (schemaTable.Rows.Count < worksheetNumber) throw new ArgumentException("The worksheet number provided cannot be found in the spreadsheet");
                string worksheet = schemaTable.Rows[worksheetNumber - 1]["table_name"].ToString().Replace("'", "");
                string sql = String.Format("select * from [{0}]", worksheet);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, connection);
                da.Fill(dataTable);
            }
            catch (Exception e)
            {
                // ???
                throw e;
            }
            finally
            {
                // free resources
                connection.Close();
            }

            // write out CSV data
            foreach (DataRow row in dataTable.Rows)
            {
                bool firstLine = true;
                foreach (DataColumn col in dataTable.Columns)
                {
                //    if (!firstLine) { wtr.Write(","); } else { firstLine = false; }
                //    var data = row[col.ColumnName].ToString().Replace("\"", "\"\"");
                //    wtr.Write(String.Format("\"{0}\"", data));
                }
                //wtr.WriteLine();
            }
        }
    }
}
