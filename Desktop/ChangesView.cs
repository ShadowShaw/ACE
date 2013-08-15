using Core;
using Desktop.Tools;
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
        private List<HistoryRecord> Changes;

        public ChangesView(List<HistoryRecord> history)
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
            DataGridTools.AddColumn(dgChanges, "Type", TextResources.Id);
            DataGridTools.AddColumn(dgChanges, "Field", TextResources.Name);
            DataGridTools.AddColumn(dgChanges, "Value", TextResources.Category);

            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Type", typeof(string));
            table.Columns.Add("Field", typeof(string));
            table.Columns.Add("Value", typeof(string));

            foreach (HistoryRecord change in Changes)
            {
                table.Rows.Add(change.Id, change.Type.ToString(), change.Field.ToString(), change.Value);
            }

            dgChanges.DataSource = table;    
        }
    }
}
