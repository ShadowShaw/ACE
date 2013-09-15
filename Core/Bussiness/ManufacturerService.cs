using PrestaAccesor.Accesors;
using PrestaAccesor.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Core.Bussiness
{
    public class ManufactuerService : ServiceBase, IService
    {
        private BackgroundWorker Worker;
        public List<manufacturer> Manufacturers;
        public ManufacturersAccesor manufacturerAccesor;

        public ManufactuerService(string BaseUrl, string Account, string Password)
        {
            manufacturerAccesor = new ManufacturersAccesor(BaseUrl, Account, "");
            Manufacturers = new List<manufacturer>();
            loaded = false;
        }

        public void Setup(string baseUrl, string apiToken)
        {
            Manufacturers.Clear();
            manufacturerAccesor.Setup(baseUrl, apiToken, "");
        }

        public void LoadManufacturersAsync(ToolStripProgressBar progressBar, ToolStripStatusLabel progressLabel)
        {
            Manufacturers.Clear();
            Manufacturers = this.manufacturerAccesor.GetAll();
            Worker = new BackgroundWorker();
            Worker.WorkerSupportsCancellation = true;
            Worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            
            if (Worker.IsBusy != true)
            {
                Worker.RunWorkerAsync();
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            List<int> ids = new List<int>();
            ids = manufacturerAccesor.GetIds();
            
            if (ids == null)
            {
                return;
            }

            foreach (int id in ids)
            {
                PrestashopEntity man = manufacturerAccesor.Get(id);
                Manufacturers.Add(man as manufacturer);
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                //this.tbProgress.Text = "Canceled!";
            }

            else if (!(e.Error == null))
            {
                //this.tbProgress.Text = ("Error: " + e.Error.Message);
            }

            else
            {
                //Worker.ReportProgress(0);
            }
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
