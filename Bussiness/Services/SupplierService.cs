using Bussiness.Base;
using PrestaAccesor.Accesors;
using PrestaAccesor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bussiness.Services
{
    public class SupplierService : ServiceBase
    {
        public List<supplier> Suppliers;
        private readonly SupplierAccesor supplierAccesor;
        
        public SupplierService(string baseUrl, string account, string password)
        {
            supplierAccesor = new SupplierAccesor(baseUrl, account, password);
            Suppliers = new List<supplier>();
            ServiceLoaded = false;
        }

        public void Setup(string url, string token)
        {
            Suppliers.Clear();
            supplierAccesor.Setup(url, token, "");
        }

        public async Task<bool> LoadSuppliersAsync()
        {
            Suppliers.Clear();
            try
            {
                return await Task.Factory.StartNew(() => LoadSuppliers());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        private bool LoadSuppliers()
        {
            List<int> ids = supplierAccesor.GetIds();

            if (ids == null)
            {
                return false;
            }

            foreach (int id in ids)
            {
                PrestashopEntity sup = supplierAccesor.Get(id);
                Suppliers.Add(sup as supplier);
            }

            ServiceLoaded = true;
            return true;
        }

        public string GetSupplierName(int id)
        {
            if (id == 0)
            {
                return "";
            }
            supplier result = Suppliers.FirstOrDefault(x => x.id == id);
            return result.name;
        }

        public string GetSupplierName(long? id)
        {
            return GetSupplierName(Convert.ToInt32(id));
        }

        public List<string> GetSupplierList()
        {
            return Suppliers.Select(item => item.name).ToList();
        }

        public long? GetSupplierIdFromEnum(string supplierName)
        {
            string searchedString = supplierName;
            
            if (supplierName == "HenrySchein")
            {
                searchedString = "Henry Schein";
            }

            if (supplierName == "AskinoTrixie")
            {
                searchedString = "Askino";
            }

            return GetSupplierId(searchedString);
        }

        public long? GetSupplierId(string supplierName)
        {
            if ((supplierName != "") && (Suppliers.Exists(s => s.name == supplierName)))
            {
                return Suppliers.FirstOrDefault(x => x.name == supplierName).id;
            }

            return -1;
        }

        public void Edit(supplier entity)
        {
            supplierAccesor.Update(entity);
        }

        public void Add(supplier entity)
        {
            supplierAccesor.Add(entity);
        }

        public supplier GetById(int id)
        {
            return supplierAccesor.Get(id) as supplier;
        }

    }
}
