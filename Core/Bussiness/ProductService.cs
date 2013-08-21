using Core.ViewModels;
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
        private BackgroundWorker Worker;
        public List<ProductViewModel> Products;
        public ProductsAccesor productsAccesor;

        public ToolStripProgressBar ProgressBar;
        public ToolStripStatusLabel ProgressLabel;
        public GroupBox FunctionBox;

        public ProductViewModel GetById(int id)
        {
            return ProductFromPresta(productsAccesor.Get(id) as product);
        }

        public ProductService(string BaseUrl, string apiToken, string Password)
        {
            productsAccesor = new ProductsAccesor(BaseUrl, apiToken, "");
            Products = new List<ProductViewModel>();
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
            Worker = new BackgroundWorker();
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
            BackgroundWorker worker = sender as BackgroundWorker;
                        
            int startItem = 0;
            
            List<product> items = new List<product>();
            do
            {
                items = productsAccesor.GetByFilter(null, null, startItem + "," + StepCount);
                startItem = startItem + StepCount;
                
                foreach (product item in items)
                {
                    Products.Add(ProductFromPresta(item));
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

        public List<ProductViewModel> GetProductWithEmptyManufacturer()
        {
            List<ProductViewModel> result = new List<ProductViewModel>();

            foreach (ProductViewModel item in this.Products)
            {
                if ((item.id_manufacturer.HasValue == false) || (item.id_manufacturer == 0))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public List<ProductViewModel> GetProductWithEmptyCategory()
        {
            List<ProductViewModel> result = new List<ProductViewModel>();

            foreach (ProductViewModel item in this.Products)
            {
                if (item.id_category_default.HasValue == false)
                {
                    result.Add(item);
                }
            }
                        
            return result;
        }

        public List<ProductViewModel> GetProductWithEmptyImage()
        {
            List<ProductViewModel> result = new List<ProductViewModel>();

            foreach (ProductViewModel item in this.Products)
            {
                if (item.id_image == 0)
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public List<ProductViewModel> GetProductWithEmptyShortDescription()
        {
            List<ProductViewModel> result = new List<ProductViewModel>();

            foreach (ProductViewModel item in this.Products)
            {
                if (item.description_short == "")
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public List<ProductViewModel> GetProductWithEmptyLongDescription()
        {
            List<ProductViewModel> result = new List<ProductViewModel>();

            foreach (ProductViewModel item in this.Products)
            {
                //if (item.description == "")
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public List<ProductViewModel> GetProductWithEmptyPrice()
        {
            List<ProductViewModel> result = new List<ProductViewModel>();

            foreach (ProductViewModel item in this.Products)
            {
                if ((item.price.HasValue == false) || (item.price <= 0))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public List<ProductViewModel> GetProductWithEmptyWholesalePrice()
        {
            List<ProductViewModel> result = new List<ProductViewModel>();

            foreach (ProductViewModel item in this.Products)
            {
                if ((item.wholesale_price.HasValue == false) || (item.price <= 0))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public List<ProductViewModel> GetProductWithEmptyWeight()
        {
            List<ProductViewModel> result = new List<ProductViewModel>();

            foreach (ProductViewModel item in this.Products)
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

        private ProductViewModel ProductFromPresta(product entity)
        {
            ProductViewModel result = new ProductViewModel();

            result.description = entity.description[activePrestaLanguage].Value;
            result.description_short = entity.description_short[activePrestaLanguage].Value;
            result.id = entity.id;
            result.id_category_default = entity.id_category_default;
            result.id_image = 0;
            result.id_manufacturer = entity.id_manufacturer;
            result.id_supplier = entity.id_supplier;
            result.name = entity.name[activePrestaLanguage].Value;
            result.price = entity.price;
            result.weight = entity.weight;
            result.wholesale_price = entity.wholesale_price;

            return result;
        }
    }
}
