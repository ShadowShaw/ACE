using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Desktop;
using Desktop.Models;


namespace Desktop
{
    class CoreX
    {
        private IEnumerable<Product> products;
        private IEnumerable<Askino> askino;
        private IEnumerable<Noviko> noviko;
        private CSVAccessor accessor;

        public const int novikoIdSupplier = 1;
        public const int askinoIdSupplier = 2;

        public CoreX()
        {
            accessor = new CSVAccessor();
        }

        public void openProducts(string filename)
        {
            products = accessor.loadCSV<Product>(filename);
        }

        public List<Product> getProducts()
        {
            return products.ToList();
        }

        public void openNoviko(string filename)
        {
            noviko = accessor.loadCSV<Noviko>(filename);
        }

        public List<Noviko> getNoviko()
        {
            return noviko.ToList();
        }

        public void openAskino(string filename)
        {
            askino = accessor.loadCSV<Askino>(filename);
        }

        public List<Askino> getAskino()
        {
            return askino.ToList();
        }

        public List<Product> checkConsistenceNoviko()
        {
            List<Product> result = new List<Product>();

            List<Product> productListNoviko = products.Select(x => x).Where(x => x.IdSupplier == novikoIdSupplier).ToList();
            List<Noviko> novikoList = noviko.Select(x => x).ToList();

            foreach (Product s in productListNoviko)
            {
                var result1 = novikoList.Where(y => y.Reference == s.Reference).ToList();
                if (result1.Count == 0)
                {
                    result.Add(s);
                }
            }

            return result;
        }

        public List<Product> checkConsistencyAskino()
        {
            List<Product> result = new List<Product>();

            List<Product> productListAskino = products.Select(x => x).Where(x => x.IdSupplier == askinoIdSupplier).ToList();
            List<Askino> askinoList = askino.Select(x => x).ToList();

            foreach (Product s in productListAskino)
            {
                var result1 = askinoList.Where(y => y.Reference == s.Reference).ToList();
                if (result1.Count == 0)
                {
                    result.Add(s);
                }
            }

            return result;
        }

        public void saveProducts(string fileName)
        {
            accessor.saveProducts(fileName, products);
        }

        public void importManufactures(string fileName)
        {
            IEnumerable<Manufacturer> manufactures;
            manufactures = accessor.loadCSV<Manufacturer>(fileName);
            
            var man = manufactures.Select(x => x.Name).ToList();
            File.WriteAllLines("manufacturers.txt", man.ToArray());
        }

        private bool isReferenceInNoviko(string reference) 
        {
            var item = noviko.Where(x => x.Reference == reference);
            if (item.ToList().Count > 0)
            {
                return true;
            }
            return false;
        }

        private bool isReferenceInAskino(string reference)
        {
            var item = askino.Where(x => x.Reference == reference);
            if (item.ToList().Count > 0)
            {
                return true;
            }
            return false;
        }

        private decimal getNovikoPrice(string reference) 
        {
            var item = noviko.Where(x => x.Reference == reference).FirstOrDefault(); //.Select(x => x.PriceWithDph).Distinct();
            return item.PriceWithDph;
        }

        private decimal getAskinoPrice(string reference)
        {
            var item = askino.Where(x => x.Reference == reference).FirstOrDefault(); //.Select(x => x.PriceWithDph).Distinct();
            return System.Convert.ToDecimal(item.PriceWithDph);
        }

        private string getOperation(string text)
        {
            string operation = text.Substring(0, 1);
            return operation;
        }

        public void repriceNoviko(string operation, int idManufacturer)
        {
            List<Product> productList = products.ToList();
            List<Product> items = products.Where(x => x.IdManufacturer == novikoIdSupplier).ToList();

            var r = getOperation(operation);
            operation = operation.Substring(1);

            for (int i = 0; i < productList.Count; i++)
            {
                if (productList[i].IdManufacturer == novikoIdSupplier)
                {
                    if (isReferenceInNoviko(productList[i].Reference))
                    {
                        if (productList[i].IdManufacturer == idManufacturer)
                        {
                            decimal novikoPrice = getNovikoPrice(productList[i].Reference);

                            if (r == "+")
                            {
                                productList[i].Price = novikoPrice + System.Convert.ToDecimal(operation);
                            }

                            if (r == "%")
                            {
                                productList[i].Price = novikoPrice * System.Convert.ToDecimal(operation);
                            }
                        }
                    }    
                }
            }
            products = productList;
        }

         public void repriceAskino(string operation, int idManufacturer)
        {
            List<Product> items = products.Where(x => x.IdManufacturer == askinoIdSupplier).ToList();

            var r = getOperation(operation);
            operation = operation.Substring(1);

            foreach (Product p in items)
            {
                if (isReferenceInAskino(p.Reference))
                {
                    if (p.IdManufacturer == idManufacturer)
                    {
                        decimal askinoPrice = getNovikoPrice(p.Reference);
                        
                        if (r == "+")
                        {
                            p.Price = askinoPrice + System.Convert.ToDecimal(operation);
                        }

                        if (r == "%")
                        {
                            p.Price = askinoPrice * System.Convert.ToDecimal(operation);
                        }
                    }
                }
            }
        }

    }
}
