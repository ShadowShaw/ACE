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
    public class ManufactuerService : ServiceBase
    {
        public List<manufacturer> Manufacturers;
        private readonly ManufacturersAccesor manufacturerAccesor;

        public ManufactuerService(string baseUrl, string account, string password)
        {
            manufacturerAccesor = new ManufacturersAccesor(baseUrl, account, password);
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
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        
        private bool LoadManufacturers()
        {
            List<int> ids = manufacturerAccesor.GetIds();
            
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
            manufacturer result = Manufacturers.FirstOrDefault(x => x.id == id);
            return result.name;
        }
        
        public List<string> GetManufacturersList()
        {
            return Manufacturers.Select(item => item.name).ToList();
        }

        public long? GetManufacturerId(string manufacturerName)
        {
            if (manufacturerName != "")
            {
                return Manufacturers.FirstOrDefault(x => x.name == manufacturerName).id;
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
