using Bussiness.Base;
using PrestaAccesor.Accesors;
using PrestaAccesor.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services
{
    public class ManufactuerService : ServiceBase
    {
        public List<manufacturer> Manufacturers;
        public ManufacturersAccesor manufacturerAccesor;

        public ManufactuerService(string BaseUrl, string Account, string Password)
        {
            manufacturerAccesor = new ManufacturersAccesor(BaseUrl, Account, "");
            Manufacturers = new List<manufacturer>();
            ServiceLoaded = false;
        }

        public void Setup(string baseUrl, string apiToken)
        {
            Manufacturers.Clear();
            manufacturerAccesor.Setup(baseUrl, apiToken, "");
        }
        
        public async Task<bool> LoadManufacturersAsync()
        {
            Manufacturers.Clear();
            try
            {
                return await Task.Factory.StartNew(() => LoadManufacturers());
            }
            catch (Exception ex)
            {
                //TODO
                //MessageBox.Show(ex.Message);
            }
            return false;
        }
        
        private bool LoadManufacturers()
        {
            List<int> ids = new List<int>();
            
            ids = manufacturerAccesor.GetIds();
            
            if (ids == null)
            {
                return false;
            }

            foreach (int id in ids)
            {
                PrestashopEntity man = manufacturerAccesor.Get(id);
                Manufacturers.Add(man as manufacturer);
            }

            ServiceLoaded = true;
            return true;
        }


        public string GetManufacturerName(int id)
        {
            if (id == 0)
            {
                return "";
            }
            manufacturer result = Manufacturers.Where(x => x.id == id).FirstOrDefault();
            return result.name;
        }
        
        public List<string> GetManufacturersList()
        {
            List<string> result = new List<string>();

            foreach (manufacturer item in Manufacturers)
            {
                result.Add(item.name);
            }

            return result;
        }

        public long? GetManufacturerId(string manufacturerName)
        {
            if (manufacturerName != "")
            {
                return Manufacturers.Where(x => x.name == manufacturerName).FirstOrDefault().id;
            }

            return 0;
        }

        public void Edit(manufacturer entity)
        {
            manufacturerAccesor.Update(entity);
        }

        public void Add(manufacturer entity)
        {
            manufacturerAccesor.Add(entity);
        }

        public manufacturer GetById(int id)
        {
            return manufacturerAccesor.Get(id) as manufacturer;
        }

    }
}
