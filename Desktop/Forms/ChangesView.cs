using Bussiness;
using Bussiness.RePricing;
using Desktop.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Desktop.Forms
{
    public partial class ChangesView : Form
    {
        private readonly List<ChangeRecord> changes;
        
        public ChangesView(List<ChangeRecord> history)
        {
            InitializeComponent();
            changes = history;    
        }

        private void BCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ChangesViewLoad(object sender, EventArgs e)
        {
            DataGridTools.InitGrid(dgChanges);

            DataGridTools.AddColumn(dgChanges, "Id", TextResources.Id);
            DataGridTools.AddColumn(dgChanges, "Type", TextResources.Type);
            DataGridTools.AddColumn(dgChanges, "Field", TextResources.Field);
            DataGridTools.AddNumberColumn(dgChanges, "Value", TextResources.Value);
            DataGridTools.AddCheckBoxColumn(dgChanges, "Confirmation", TextResources.Confirmation);

            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Type", typeof(string));
            table.Columns.Add("Field", typeof(string));
            table.Columns.Add("Value", typeof(string));
            table.Columns.Add("Confirmation", typeof(bool));

            foreach (ChangeRecord change in changes)
            {
                table.Rows.Add(change.Id, GetChangeType(change.Type), GetChangeField(change.Field), change.Value, true);
            }
            
            dgChanges.DataSource = table;

            foreach (DataGridViewRow row in dgChanges.Rows)
            {
                row.Cells["Confirmation"].Value = true;
            } 
        }

        private string GetChangeType(RecordType type)
        {
            string result = "Neznamý";
            if (type == RecordType.Product)
            {
                result = "Produkt";
            }
            return result;
        }

        private string GetChangeField(FieldType field)
        {
            string result = "Neznamé";
            if (field == FieldType.Category)
            {
                result = TextResources.Category;
            }
            if (field == FieldType.Image)
            {
                result = TextResources.ProductImage;
            }
            if (field == FieldType.LongDescription)
            {
                result = TextResources.Description;
            }
            if (field == FieldType.Manufacturer)
            {
                result = TextResources.Manufacturer;
            }
            if (field == FieldType.Price)
            {
                result = TextResources.SalePrice;
            }
            if (field == FieldType.ShortDescription)
            {
                result = TextResources.ShortDescription;
            }
            if (field == FieldType.Weight)
            {
                result = TextResources.Weight;
            }
            if (field == FieldType.WholesalePrice)
            {
                result = TextResources.WholeSalePrice;
            }
            if (field == FieldType.Supplier)
            {
                result = TextResources.Supplier;
            }
            return result;
        }
        
        private void BOkClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
