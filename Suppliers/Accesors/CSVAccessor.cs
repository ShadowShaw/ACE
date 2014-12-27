using System;
using System.Collections.Generic;
using System.Linq;
using LINQtoCSV;
using Suppliers.Interfaces;
using Suppliers.Suppliers;

namespace Suppliers.Accesors
{
    public class CsvAccessor : IAccessor
    {
        private readonly CsvFileDescription _inputFileDescription;
        private readonly CsvContext _context;
       
        public CsvAccessor()
        {
            _inputFileDescription = new CsvFileDescription
            {
                SeparatorChar = ';',
                FirstLineHasColumnNames = false,
                EnforceCsvColumnAttribute = true,
                MaximumNbrExceptions = 50,
                FileCultureName = "en-US"
            };

            _context = new CsvContext();
        }

        public IEnumerable<T> Load<T>(string filename) where T : class, ISupplierModel, new()
        {
            IEnumerable<T> result = null;
            try
            {
                result = _context.Read<T>(filename, _inputFileDescription).ToList();
            }
            catch (AggregatedException ae)
            {
                List<Exception> innerExceptionsList = (List<Exception>)ae.Data["InnerExceptionsList"];
            }
            //catch (DuplicateFieldIndexException dfie)
            //{
            //    //string typeName = Convert.ToString(dfie.Data["TypeName"]);

            //    //string fieldName = Convert.ToString(dfie.Data["FieldName"]);
            //    //string fieldName2 = Convert.ToString(dfie.Data["FieldName2"]);

            //    //int commonFieldIndex = Convert.ToInt32(dfie.Data["Index"]);
            //}
            //catch (Exception /*e*/)
            //{
            //    //something
            //}
            return result;
        }
    }
}
