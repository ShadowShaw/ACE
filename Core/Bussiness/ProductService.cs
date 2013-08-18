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
    public class ProductService : ServiceBase
    {
        private ResourceBackgroundWorker Worker;
        public List<product> Products;
        public ProductsAccesor productsAccesor;

        public ToolStripProgressBar ProgressBar;
        public ToolStripStatusLabel ProgressLabel;
        public GroupBox FunctionBox;

        public product GetById(int id)
        {
            return productsAccesor.Get(id) as product;
        }

        public ProductService(string BaseUrl, string Account, string Password)
        {
            productsAccesor = new ProductsAccesor(BaseUrl, Account, "");
            Products = new List<product>();
            loaded = false;
        }

        public void Setup()
        {
            productsAccesor.Setup(baseUrl, apiToken, "");
        }

        public void LoadProductsAsync(ToolStripProgressBar progressBar, ToolStripStatusLabel progressLabel, GroupBox gb)
        {
            this.ProgressBar = progressBar;
            this.ProgressLabel = progressLabel;
            this.FunctionBox = gb;
            Worker = new ResourceBackgroundWorker();
            Worker.WorkerReportsProgress = true;
            Worker.WorkerSupportsCancellation = true;
            Worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            Worker.ProgressChanged +=  new ProgressChangedEventHandler(worker_ProgressChanged);
            Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            
            if (Worker.IsBusy != true)
            {
                Worker.RunWorkerAsync();
            }
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                this.ProgressBar.Visible = false;
                this.ProgressLabel.Text = "";
            }
            if (e.ProgressPercentage == 1)
            {
                this.ProgressBar.Visible = true;
                this.ProgressLabel.Text = "Načítám produkty, prosím čekejte...";
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Worker.ReportProgress(1);
            ResourceBackgroundWorker worker = sender as ResourceBackgroundWorker;
                        
            int startItem = 0;
            
            List<product> items = new List<product>();
            do
            {
                items = productsAccesor.GetByFilter(null, null, startItem + "," + StepCount);
                startItem = startItem + StepCount;
                
                foreach (product item in items)
                {
                    Products.Add(item);
                }
                
            } while (items.Count == 500);
            
            Worker.ReportProgress(0);
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FunctionBox.Enabled = true;
            ProgressBar.Visible = false;
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
        
        public List<product> GetProductWithEmptyManufacturer()
        {
            List<product> result = new List<product>();

            foreach (product item in this.Products)
            {
                if (item.id_manufacturer.HasValue == false)
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public List<product> GetProductWithEmptyCategory()
        {
            List<product> result = new List<product>();

            foreach (product item in this.Products)
            {
                if (item.id_category_default.HasValue == false)
                {
                    result.Add(item);
                }
            }
                        
            return result;
        }

        public List<product> GetProductWithEmptyImage()
        {
            List<product> result = new List<product>();

            foreach (product item in this.Products)
            {
                //if (item.id_image == 0)
                //{
                //    result.Add(item);
                //}
            }

            return result;
        }

            public List<product> GetProductWithEmptyShortDescription()
        {
            List<product> result = new List<product>();

            foreach (product item in this.Products)
            {
                //if (item.description_short == "")
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public List<product> GetProductWithEmptyLongDescription()
        {
            List<product> result = new List<product>();

            foreach (product item in this.Products)
            {
                //if (item.description == "")
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public List<product> GetProductWithEmptyPrice()
        {
            List<product> result = new List<product>();

            foreach (product item in this.Products)
            {
                if ((item.price.HasValue == false) || (item.price <= 0))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public List<product> GetProductWithEmptyWholesalePrice()
        {
            List<product> result = new List<product>();

            foreach (product item in this.Products)
            {
                if ((item.wholesale_price.HasValue == false) || (item.price <= 0))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public List<product> GetProductWithEmptyWeight()
        {
            List<product> result = new List<product>();

            foreach (product item in this.Products)
            {
                if ((item.weight.HasValue == false) || (item.weight <= 0))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public void Edit(product entity)
        {
            productsAccesor.Update(entity);
        }

        public void Add(product entity)
        {
            productsAccesor.Add(entity);
        }

        public string GetProductName(int id)
        {
            int productIndex = Products.FindIndex(product => product.id == id);
            int languageIndex = Products[productIndex].name.FindIndex(language => language.id == activeLanguage);
            return Products[productIndex].name[languageIndex].Value;
        }

        public string GetProductShortDescription(int id)
        {
            int productIndex = Products.FindIndex(product => product.id == id);
            int languageIndex = Products[productIndex].description_short.FindIndex(language => language.id == activeLanguage);
            return Products[productIndex].description_short[languageIndex].Value;
        }

        public string GetProductDescription(int id)
        {
            int productIndex = Products.FindIndex(product => product.id == id);
            int languageIndex = Products[productIndex].description.FindIndex(language => language.id == activeLanguage);
            return Products[productIndex].description[languageIndex].Value;
        }
    }
}
