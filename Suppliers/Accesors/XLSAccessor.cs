using System.Collections.Generic;
using System.Data;
using System.IO;
using Excel;
using Suppliers.Interfaces;

namespace Suppliers.Accesors
{
    public class XlsAccessor : IAccessor
    {
        public IEnumerable<T> Load<T>(string fileName) where T : class, ISupplierModel, new()
        {
            T item;
            int tableIndex = new T().GetFileTableIndex();
            
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(fileName);
            }

            FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);

            IExcelDataReader excelReader = null;
            string extension = Path.GetExtension(fileName);

            if (extension == ".xls")
            {
                // Reading from a binary Excel file ('97-2003 format; *.xls).
                excelReader = ExcelReaderFactory.CreateBinaryReader(stream);    
            }

            if (extension == ".xlsx")
            {
                //Reading from a OpenXml Excel file (2007 format; *.xlsx).
                excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            }

            IList<T> result = null;

            if (excelReader != null)
            {
                DataSet dataset = excelReader.AsDataSet();
                if ((dataset.Tables.Count-1) < tableIndex) // Adjustment for second part of Askino
                {
                    tableIndex = 0;
                }
                
                result = dataset.Tables[tableIndex].ToList<T>(new T().GetMapping());

                excelReader.Close();    
            }
            
            return result;
        }
    }
}
