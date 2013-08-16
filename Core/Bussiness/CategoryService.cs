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

        public bool GetFirstCategory()
        {
            bool result = false;

            prestashopentity cat = m_categoriesAccesor.Get(1);
            if (cat != null)
            {
                result = true;
            }

            return result;

        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            ResourceBackgroundWorker worker = sender as ResourceBackgroundWorker;

            List<int> ids = new List<int>();
            ids = m_categoriesAccesor.GetIds();
            
            foreach (int id in ids)
            {
                prestashopentity cat = m_categoriesAccesor.Get(id);
                Categories.Add(cat as category );
            }
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

        public string GetCategoryName(int id)
        {
            if (id == 0)
            {
                return "";
            }

            category result = Categories.Where(x => x.id == id).FirstOrDefault();
            return result.name;
        }

        public int? GetCategoryId(string categoryName)
        {
            if (categoryName != "")
            {
                return Categories.Where(x => x.name == categoryName).FirstOrDefault().id;
            }

            return 0;
        }

        public List<string> GetCategoryList()
        { 
            List<string> result = new List<string>();

            foreach (category item in Categories)
            {
                result.Add(item.name);
            }

            return result;
        }
    }
}
