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
    public class CategoryService : ServiceBase, IService
    {
        private BackgroundWorker Worker;
        public List<category> Categories;
        public CategoriesAccesor categoriesAccesor;
                
        public CategoryService(string BaseUrl, string Account, string Password)
        {
            categoriesAccesor = new CategoriesAccesor(BaseUrl, Account, "");
            Categories = new List<category>();
            loaded = false;
        }

        public void Setup()
        {
            categoriesAccesor.Setup(baseUrl, apiToken, "");
        }

        public void LoadCategoriesAsync()
        {
            Categories.Clear();
            Worker = new BackgroundWorker();
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
            BackgroundWorker worker = sender as BackgroundWorker;

            List<int> ids = new List<int>();
            ids = categoriesAccesor.GetIds();

            if (ids == null)
            {
                return;
            }
            
            foreach (int id in ids)
            {
                PrestashopEntity cat = categoriesAccesor.Get(id);
                Categories.Add(cat as category );
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loaded = true;
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

        public long? GetCategoryId(string categoryName)
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
