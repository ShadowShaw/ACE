using System;
using System.Collections.Generic;
using System.Linq;
using LINQtoCSV;
using Suppliers.Interfaces;

namespace Suppliers.Accesors
{
    public class CSVAccessor : IAccessor
    {
        private readonly CsvFileDescription inputFileDescription;
        private readonly CsvContext context;
       
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

            context = new CsvContext();
        }

        public IEnumerable<T> Load<T>(string filename) where T : class, new()
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
