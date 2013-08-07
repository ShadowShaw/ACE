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
    public class CategoryService
    {
        private ResourceBackgroundWorker Worker;
        public List<category> Categories;
        public CategoriesAccesor m_categoriesAccesor;

        public const int StepCount = 500;

        private bool m_loaded;

        public bool Loaded
        {
            get
            {
                return m_loaded;
            }
        }

        public CategoryService(string BaseUrl, string Account, string Password)
        {
            m_categoriesAccesor = new CategoriesAccesor(BaseUrl, Account, "");
            Categories = new List<category>();
            m_loaded = false;
        }

        public void Setup(string BaseUrl, string Account, string Password)
        {
            m_categoriesAccesor.Setup(BaseUrl, Account, "");
        }

        public void LoadCategoriesAsync()
        {
            Worker = new ResourceBackgroundWorker();
            Worker.WorkerReportsProgress = true;
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

            List<int> ids = m_categoriesAccesor.GetIdsPartial();
            worker.ReportProgress(15);

            int startItem = 0;
            
            List<category> items = new List<category>();
            do
            {
                items = m_categoriesAccesor.GetByFilter(null, null, startItem + "," + StepCount);
                startItem = startItem + StepCount;

                foreach (category item in items)
                {
                    Categories.Add(item);
                }
            } while (items.Count == 500);
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            m_loaded = true;
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

        private string GetCategoryName(int id)
        {
            category result = Categories.Where(x => x.id == id).FirstOrDefault();
            return result.name;
        }
    }
}
