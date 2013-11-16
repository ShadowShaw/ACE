using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using LINQtoCSV;

namespace Core.Suppliers
{
    public class CSVAccessor
    {
        private CsvFileDescription inputFileDescription;
        private CsvFileDescription outputFileDescription;
        private CsvContext context;
       
        public CSVAccessor()
        {
            inputFileDescription = new CsvFileDescription
            {
                SeparatorChar = ';',
                FirstLineHasColumnNames = false,
                EnforceCsvColumnAttribute = true,
                MaximumNbrExceptions = 50,
                FileCultureName = "en-US"
            };

            outputFileDescription = new CsvFileDescription
            {
                SeparatorChar = ';', // tab delimited
                FirstLineHasColumnNames = false, // no column names in first record
                EnforceCsvColumnAttribute = true,
                MaximumNbrExceptions = 50,
                FileCultureName = "en-US"
            };

            context = new CsvContext();
        }

        public IEnumerable<T> loadCSV<T>(string filename) where T : class, new()
        {
            IEnumerable<T> result = null;
            try
            {
                result = context.Read<T>(filename, inputFileDescription).ToList();
            }
            catch (AggregatedException ae)
            {
                List<Exception> innerExceptionsList = (List<Exception>)ae.Data["InnerExceptionsList"];
            }
            catch (DuplicateFieldIndexException dfie)
            {
                string typeName = Convert.ToString(dfie.Data["TypeName"]);

                string fieldName = Convert.ToString(dfie.Data["FieldName"]);
                string fieldName2 = Convert.ToString(dfie.Data["FieldName2"]);

                int commonFieldIndex = Convert.ToInt32(dfie.Data["Index"]);
            }
            catch (Exception /*e*/)
            {
                //something
            }
            return result;
        }
    }
}
