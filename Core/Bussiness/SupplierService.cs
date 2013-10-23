﻿using Desktop.Models;
using PrestaAccesor.Accesors;
using PrestaAccesor.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Core.Bussiness
{
    public class SupplierService : ServiceBase, IService
    {
        public List<supplier> Suppliers;
        public SupplierAccesor supplierAccesor;
        private List<Askino> askino;
        private List<Noviko> noviko;

        public SupplierService(string BaseUrl, string Account, string Password)
        {
            supplierAccesor = new SupplierAccesor(BaseUrl, Account, "");
            Suppliers = new List<supplier>();
            loaded = false;
        }

        public void Setup(string baseUrl, string apiToken)
        {
            Suppliers.Clear();
            supplierAccesor.Setup(baseUrl, apiToken, "");
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
            List<int> ids = new List<int>();

            ids = supplierAccesor.GetIds();

            if (ids == null)
            {
                return false;
            }

            foreach (int id in ids)
            {
                PrestashopEntity sup = supplierAccesor.Get(id);
                Suppliers.Add(sup as supplier);
            }

            loaded = true;
            return true;
        }


        public string GetSupplierName(int id)
        {
            if (id == 0)
            {
                return "";
            }
            supplier result = Suppliers.Where(x => x.id == id).FirstOrDefault();
            return result.name;
        }

        public List<string> GetSupplierList()
        {
            List<string> result = new List<string>();

            foreach (supplier item in Suppliers)
            {
                result.Add(item.name);
            }

            return result;
        }

        public long? GetSupplierId(string supplierName)
        {
            if (supplierName != "")
            {
                return Suppliers.Where(x => x.name == supplierName).FirstOrDefault().id;
            }

            return 0;
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
