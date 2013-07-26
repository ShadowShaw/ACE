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

        public void LoadProductsAsync(ToolStripProgressBar progressBar, ToolStripStatusLabel progressLabel)
        {
            Worker = new ResourceBackgroundWorker();
            Worker.WorkerReportsProgress = true;
            Worker.WorkerSupportsCancellation = true;
            Worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            Worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            Worker.progressBar = progressBar;
            Worker.progressLabel = progressLabel;

            if (Worker.IsBusy != true)
            {
                Worker.RunWorkerAsync();
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            ResourceBackgroundWorker worker = sender as ResourceBackgroundWorker;

            worker.progressLabel.Text = "Načítám kategorie, prosím čekejte...";
            worker.ReportProgress(5);
            List<int> ids = m_manufacturerAccesor.GetIdsPartial();
            worker.ReportProgress(15);

            int startItem = 0;
            double step = 85.0 / (ids.Count / 500.0);
            Math.Floor(step);

            double progress = 12.0;

            List<manufacturer> items = new List<manufacturer>();
            do
            {
                items = m_manufacturerAccesor.GetByFilter(null, null, startItem + "," + StepCount);
                startItem = startItem + StepCount;

                foreach (manufacturer item in items)
                {
                    Manufacturers.Add(item);
                }
                progress = progress + step;
                worker.ReportProgress(System.Convert.ToInt32(progress));

            } while (items.Count == 500);
            worker.ReportProgress(0);
            worker.progressLabel.Text = "Načítám kategorie, hotovo.";
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

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ResourceBackgroundWorker worker = sender as ResourceBackgroundWorker;
            worker.progressBar.Value = (e.ProgressPercentage);
        }
    }
}
