using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

using Core.Bussiness;
using PrestaAccesor.Serializers;
using Desktop.UserSettings;
using PrestaAccesor.Entities;
using Core;
using Desktop.Tools;

namespace Desktop
{
    public partial class Main : Form
    {
        CoreX coreX;

        List<category> test = new List<category>();
        List<HistoryRecord> history = new List<HistoryRecord>();
        public EngineService Engine;
        private MainSettings mainSettings;

        private VersionService Version = new VersionService();

        public Main()
        {
            InitializeComponent();
            coreX = new CoreX();
            Engine = new EngineService();

            this.Text = "ACE Desktop " + Version.AssemblyVersion;

            // Loading settings from configuration.
            mainSettings = new MainSettings();
            ePrestaToken.Text = mainSettings.PrestaApiToken;
            ePrestaUrl.Text = mainSettings.PrestaBaseUrl;
            Engine.PrestaSetup(mainSettings.PrestaBaseUrl, mainSettings.PrestaApiToken);

            // Lenght of edit boxes.
            ePrestaToken.MaxLength = 50;
            ePrestaUrl.MaxLength = 100;
            
            // Old Code.
            openDialog.InitialDirectory = Application.StartupPath;
            saveDialog.InitialDirectory = Application.StartupPath;
            
            if (File.Exists("manufacturers.txt"))
            {
                var u = File.ReadAllLines("manufacturers.txt").ToList();
                foreach (string s in u)
                {
                    cManufacturers.Items.Add(s);
                }

                cManufacturers.SelectedIndex = 0;
            }
        }
        
        
        private void bSave_Click(object sender, EventArgs e)
        {
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                coreX.saveProducts(saveDialog.FileName);
            }
        }

        private void openZverac_Click(object sender, EventArgs e)
        {
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                coreX.openProducts(openDialog.FileName);
                statusAgent.Enabled = true;
                dgView.DataSource = coreX.getProducts();
            }
        }

        private void openAskino_Click(object sender, EventArgs e)
        {
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                coreX.openAskino(openDialog.FileName);
                statusPresta.Enabled = true;
                dgView.DataSource = coreX.getAskino();
            }
        }

        private void openNoviko_Click(object sender, EventArgs e)
        {
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                coreX.openNoviko(openDialog.FileName);
                statusLogin.Enabled = true;
                dgView.DataSource = coreX.getNoviko();
            }
        }

        private void bConsistencyNoviko_Click(object sender, EventArgs e)
        {
            if ((statusAgent.Enabled) && (statusLogin.Enabled))
            {
                dgView.DataSource = coreX.checkConsistenceNoviko();
            }
            else
            {
                //ShowMessage("Otevřete ceníky Zveráče a Novika");
            }
        }

        private void bConsistencyAskino_Click(object sender, EventArgs e)
        {
            if ((statusAgent.Enabled) && (statusPresta.Enabled))
            {
                dgView.DataSource = coreX.checkConsistencyAskino();
            }
            else
            {
                //ShowMessage("Otevřete ceníky Zveráče a Askina");
            }
        }

        private void importManufactures_Click(object sender, EventArgs e)
        {
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                coreX.importManufactures(openDialog.FileName);
            }
        }

        private string getOperation(string text)
        {
            string operation = text.Substring(0, 1);
            return operation;
        }

        private void bReprice_Click(object sender, EventArgs e)
        {
            //if (rAskino.Checked)
            //{
            //    coreX.repriceAskino(eReprice.Text, cManufacturers.SelectedIndex);
            //}

            //if (rNoviko.Checked)
            //{
            //    coreX.repriceNoviko(eReprice.Text, cManufacturers.SelectedIndex);
            //}

            dgView.DataSource = coreX.getProducts();
        }

        private static void PopulateTree(TreeView tree, ICollection<TreeItem> items)
        {
            tree.Nodes.Clear();
            List<TreeNode> roots = new List<TreeNode>();
            roots.Add(tree.Nodes.Add("-1", "Kategorie Eshopu"));
            foreach (TreeItem item in items)
            {
                if (item.Level == roots.Count)
                {
                    roots.Add(roots[roots.Count - 1].LastNode);
                }

                roots[item.Level].Nodes.Add(item.Id.ToString(), item.Name);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            PopulateTree(CategoryTree, Engine.CreateCategoryTreeList());
            CategoryTree.ExpandAll();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //homeBrowser.Document = ""
            ToolTip toolTip = new ToolTip();

            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;

            toolTip.SetToolTip(this.bLoadProducts, TextResources.hLoadProducts);
            toolTip.SetToolTip(this.bEmptyCategory, TextResources.hEmptyCategory);
            toolTip.SetToolTip(this.bEmptyManufacturer, TextResources.hEmptyManufacturer);
            toolTip.SetToolTip(this.bWithoutImage, TextResources.hWithoutImage);
            toolTip.SetToolTip(this.bWithoutShortDescription, TextResources.hWithoutShortDescription);
            toolTip.SetToolTip(this.bWithoutLongDescription, TextResources.hWithoutLongDescription);
            toolTip.SetToolTip(this.bWithoutPrice, TextResources.hWithoutPrice);
            toolTip.SetToolTip(this.bWithoutWholeSalePrice, TextResources.hWithoutWholeSalePrice);
            toolTip.SetToolTip(this.bWithoutWeight, TextResources.hWithoutWeight);
            
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            var LoginForm = new Login(Engine);
            if (LoginForm.ShowDialog() == DialogResult.OK)
            {

            }
            else
            {
                MessageBox.Show("Pro použití ACE se musíte přihlásit.");
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TreeNode x = CategoryTree.SelectedNode;
            int a = System.Convert.ToInt32(x.Name);
        }
        
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainSettings.Save();
        }

        private void bSavePresta_Click(object sender, EventArgs e)
        {
            string token = UITools.GetStringFromEditBox(ePrestaToken);
            string url = UITools.GetBaseUrlFromEditBox(ePrestaUrl);

            ePrestaUrl.Text = url;
            ePrestaToken.Text = token;
            Engine.PrestaSetup(url, token);
            mainSettings.PrestaBaseUrl = Engine.BaseUrl;
            mainSettings.PrestaApiToken = Engine.ApiToken;
            mainSettings.Save();
        }

        private void bEmptyCategory_Click(object sender, EventArgs e)
        {
            lListOf.Text = "Zobrazuji produkty s prázdnou kategorii.";
            DataGridTools.InitGrid(dgConsistency);
            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyCategory();

            DataGridTools.AddColumn(dgConsistency, "id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "id_category_default", TextResources.Category, false);
        }

        private void bEmptyManufacturer_Click(object sender, EventArgs e)
        {
            lListOf.Text = "Zobrazuji produkty s prázdným výrobcem.";
            DataGridTools.InitGrid(dgConsistency);
            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyManufacturer();

            DataGridTools.AddColumn(dgConsistency, "id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "id_category_default", TextResources.Category);
            DataGridTools.AddColumn(dgConsistency, "id_manufacturer", TextResources.Manufacturer, false);
        }

        private void bWithoutImage_Click(object sender, EventArgs e)
        {
            lListOf.Text = "Zobrazuji produkty bez obrázku.";
            DataGridTools.InitGrid(dgConsistency);
            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyImage();

            DataGridTools.AddColumn(dgConsistency, "id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "id_category_default", TextResources.Category);
            DataGridTools.AddColumn(dgConsistency, "id_image", TextResources.ProductImage, false);
        }

        private void bWithoutShortDescription_Click(object sender, EventArgs e)
        {
            lListOf.Text = "Zobrazuji produkty s prázdným krátkým popisem.";
            DataGridTools.InitGrid(dgConsistency);
            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyShortDescription();

            DataGridTools.AddColumn(dgConsistency, "id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "id_category_default", TextResources.Category);
            DataGridTools.AddColumn(dgConsistency, "description_short", TextResources.ShortDescription, false);
        }

        private void bWithoutLongDescription_Click(object sender, EventArgs e)
        {
            lListOf.Text = "Zobrazuji produkty s prázdným dlouhým popisem.";
            DataGridTools.InitGrid(dgConsistency);
            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyLongDescription();

            DataGridTools.AddColumn(dgConsistency, "id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "id_category_default", TextResources.Category);
            DataGridTools.AddColumn(dgConsistency, "description", TextResources.Description, false);
        }

        private void bWithoutPrice_Click(object sender, EventArgs e)
        {
            lListOf.Text = "Zobrazuji produkty bez maloobchodní ceny.";
            DataGridTools.InitGrid(dgConsistency);
            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyPrice();

            DataGridTools.AddColumn(dgConsistency, "id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "id_category_default", TextResources.Category);
            DataGridTools.AddColumn(dgConsistency, "price", TextResources.SalePrice, false);
        }

        private void bWithoutWeight_Click(object sender, EventArgs e)
        {
            lListOf.Text = "Zobrazuji produkty bez udané váhy.";
            DataGridTools.InitGrid(dgConsistency);
            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyWeight();

            DataGridTools.AddColumn(dgConsistency, "id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "id_category_default", TextResources.Category);
            DataGridTools.AddColumn(dgConsistency, "weight", TextResources.Weight, false);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Engine.Manufacturers.LoadManufacturersAsync(statusProgress, statusMessage);
            Engine.Categories.LoadCategoriesAsync();
            Engine.Products.LoadProductsAsync(statusProgress, statusMessage, gbConsistency );
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String strVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void bWithoutWholeSalePrice_Click(object sender, EventArgs e)
        {
            lListOf.Text = "Zobrazuji produkty bez velkoobchodní ceny.";
            DataGridTools.InitGrid(dgConsistency);
            dgConsistency.DataSource = Engine.Products.GetProductWithEmptyWholesalePrice();

            DataGridTools.AddColumn(dgConsistency, "id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "name", TextResources.Name);
            DataGridTools.AddColumn(dgConsistency, "id_category_default", TextResources.Category);
            DataGridTools.AddColumn(dgConsistency, "wholesale_price", TextResources.WholeSalePrice, false);
        }
        
        private void dgConsistency_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == this.dgConsistency.Columns["id_category_default"].Index)
            //{
            //    string value = dgConsistency[e.ColumnIndex, e.RowIndex].Value.ToString();
            //    int id = System.Convert.ToInt32(dgConsistency["id", e.RowIndex].Value);

            //    HistoryRecord record = new HistoryRecord();
            //    record.Type = RecordType.product;
            //    record.Field = FieldType.category;
            //    record.Id = id;
            //    record.Value = value;

            //    history.Add(record);
            //}
        }

        private List<product> GetTestList()
        {
            List<product> testList = new List<product>();
            product p1 = new product();
            product p2 = new product();
            p1.id = 1;
            p2.id = 2;
            p1.name = "rrr";
            p2.name = "rtttt";
            p1.id_category_default = 1;
            p2.id_category_default = 2;

            testList.Add(p1);
            testList.Add(p2);

            return testList;
        }


        public class ComboValue
        {
            public int Id;
            public string Desc;
        }

        private List<category> GetCatList()
        {

            List<category> ccc = new List<category>();
            category c1 = new category();
            category c2 = new category();
            c1.id = 1;
            c2.id = 2;
            c1.name = "aaa";
            c2.name = "bbb";
            ccc.Add(c1);
            ccc.Add(c2);

            return ccc;
        }

        public static void AddColumnCombo(DataGridView grid, string dataProperty, string header, bool readOnly = true)
        {
            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();

            //DataGridViewCell cell = new DataGridViewComboBoxCell();
            //column.CellTemplate = cell;
            column.HeaderText = header;
            column.ReadOnly = readOnly;
            column.Name = dataProperty;
            column.Items.Add("jedna");
            column.Items.Add("dva");
            //column.DataPropertyName = dataProperty;



            //column.DataSource = GetCatList();
            //column.ValueMember = "id";
            //column.DisplayMember = "name";

            grid.Columns.Add(column);


        }

        private void button3_Click_2(object sender, EventArgs e)
        {
           lListOf.Text = "Zobrazuji produkty bez velkoobchodní ceny.";
           DataGridTools.InitGrid(dgConsistency);
            //dgConsistency.DataSource = Engine.Products.GetProductWithEmptyShortDescription();

            DataGridTools.AddColumn(dgConsistency, "id", TextResources.Id);
            DataGridTools.AddColumn(dgConsistency, "name", TextResources.Name);
            //DataGridTools.AddColumn(dgConsistency, "id_category_default", TextResources.Category, false);
            AddColumnCombo(dgConsistency, "category_default", TextResources.Category, false);

            dgConsistency.DataSource = GetTestList();

            for (int i = 0; i < dgConsistency.Rows.Count; i++)
            {
                DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)dgConsistency.Rows[i].Cells["category_default"];
                comboCell.Value = "jedna";
            };
        }
 
        //delegate void SetComboBoxCellType(int iRowIndex);
        //bool bIsComboBox = false;

        private void dgConsistency_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
        //    SetComboBoxCellType objChangeCellType = new SetComboBoxCellType(ChangeCellToComboBox);

        //    if (e.ColumnIndex == this.dgConsistency.Columns["id_category_default"].Index)
        //    {
        //        this.dgConsistency.BeginInvoke(objChangeCellType, e.RowIndex);
        //        bIsComboBox = false;
        //    }
        }

        //private void ChangeCellToComboBox(int iRowIndex)
        //{
        //    if (bIsComboBox == false)
        //    {
        //        DataGridViewComboBoxCell dgComboCell = new DataGridViewComboBoxCell();
        //        //dgComboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;

        //        DataTable dt = new DataTable();
        //        dt.Columns.Add("cat", typeof(string));
                
        //        for (int i = 0; i < 5; i++)
        //        {
        //            DataRow dr = dt.NewRow();
        //            dr["cat"] = "Name - " + i.ToString();
                    

        //            dt.Rows.Add(dr);
        //        }


        //        dgComboCell.DataSource = dt; // GetTestList();
        //        dgComboCell.ValueMember = "cat";
        //        dgComboCell.DisplayMember = "cat";
        //        //dgComboCell.Items.Add("jedna");
        //        //dgComboCell.Items.Add("dva");
        //        dgComboCell.FlatStyle = FlatStyle.Flat;

        //        dgConsistency.Rows[iRowIndex].Cells[dgConsistency.CurrentCell.ColumnIndex] = dgComboCell;
        //        bIsComboBox = true;
        //    }
        //}

        private void dgConsistency_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //dgConsistency.Rows[e.RowIndex].Cells["category_default"].Value = 1;
        //    //if (this.dgConsistency.Columns[e.ColumnIndex].Name == "id_category_default")
        //    //{
        //    //    string value = dgConsistency[e.ColumnIndex, e.RowIndex].Value.ToString();
        //    //    e.Value = e.Value.ToString() + " c1";
        //    //}
        }         
    }
}
