﻿using Bussiness;
using Desktop.UserSettings;
using Desktop.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Desktop
{
    public partial class ChangesView : Form
    {
        private List<ChangeRecord> Changes;
        
        public ChangesView(List<ChangeRecord> history)
        {
            InitializeComponent();
            Changes = history;    
        }

        private void bCancel_Click(object sender, EventArgs e)
        {

        }

        private void ChangesView_Load(object sender, EventArgs e)
        {
            DataGridTools.InitGrid(dgChanges);

            DataGridTools.AddColumn(dgChanges, "Id", TextResources.Id);
            DataGridTools.AddColumn(dgChanges, "Type", TextResources.Type);
            DataGridTools.AddColumn(dgChanges, "Field", TextResources.Field);
            DataGridTools.AddColumn(dgChanges, "Value", TextResources.Value);
            DataGridTools.AddCheckBoxColumn(dgChanges, "Confirmation", TextResources.Confirmation);

            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Type", typeof(string));
            table.Columns.Add("Field", typeof(string));
            table.Columns.Add("Value", typeof(string));
            table.Columns.Add("Confirmation", typeof(bool));

            foreach (ChangeRecord change in Changes)
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
            if (type == RecordType.product)
            {
                result = "Produkt";
            }
            return result;
        }

        private string GetChangeField(FieldType field)
        {
            string result = "Neznamé";
            if (field == FieldType.category)
            {
                result = TextResources.Category;
            }
            if (field == FieldType.image)
            {
                result = TextResources.ProductImage;
            }
            if (field == FieldType.longDescription)
            {
                result = TextResources.Description;
            }
            if (field == FieldType.manufacturer)
            {
                result = TextResources.Manufacturer;
            }
            if (field == FieldType.price)
            {
                result = TextResources.SalePrice;
            }
            if (field == FieldType.shortDescription)
            {
                result = TextResources.ShortDescription;
            }
            if (field == FieldType.weight)
            {
                result = TextResources.Weight;
            }
            if (field == FieldType.wholesalePrice)
            {
                result = TextResources.WholeSalePrice;
            }
            if (field == FieldType.supplier)
            {
                result = TextResources.Supplier;
            }
            return result;
        }
        
        private void bOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
