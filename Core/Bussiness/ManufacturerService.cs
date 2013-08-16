using PrestaAccesor.Accesors;
using PrestaAccesor.Entities;
using PrestaAccesor.Serializers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Core.Bussiness
{
    public class ManufactuerService
    {
        private ResourceBackgroundWorker Worker;
        public List<manufacturer> Manufacturers;
        public ManufacturersAccesor m_manufacturerAccesor;

        public const int StepCount = 500;

        private bool m_loaded;

        public bool Loaded
        {
            get
            {
                return m_loaded;
            }
        }

        public ManufactuerService(string BaseUrl, string Account, string Password)
        {
            m_manufacturerAccesor = new ManufacturersAccesor(BaseUrl, Account, "");
            Manufacturers = new List<manufacturer>();
            m_loaded = false;
        }

        public void Setup(string BaseUrl, string Account, string Password)
        {
            m_manufacturerAccesor.Setup(BaseUrl, Account, "");
        }

        public void LoadManufacturersAsync(ToolStripProgressBar progressBar, ToolStripStatusLabel progressLabel)
        {
            Worker = new ResourceBackgroundWorker();
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
            ResourceBackgroundWorker worker = sender as ResourceBackgroundWorker;

            List<int> ids = new List<int>();
            ids = m_manufacturerAccesor.GetIds();

            foreach (int id in ids)
            {
                prestashopentity man = m_manufacturerAccesor.Get(id);
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

        public int? GetManufacturerId(string manufacturerName)
        {
            if (manufacturerName != "")
            {
                return Manufacturers.Where(x => x.name == manufacturerName).FirstOrDefault().id;
            }

            return 0;
        }

    }
}
