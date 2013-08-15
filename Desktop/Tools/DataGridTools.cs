using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Desktop.Tools
{
    public enum RecordType
    {
        product = 0
    }

    public enum FieldType
    {
        category = 0,
        manufacturer = 1,
        image,
        shortDescription,
        longDescription,
        price,
        weight,
        wholesalePrice
    }

    public class HistoryRecord
    {
        public RecordType Type;
        public FieldType Field;
        public int Id;
        public string Value;
    }

    public class DataGridTools
    {

        public static void AddComboBoxColumn(DataGridView grid, string dataProperty, string header, List<string> items, bool readOnly = true, bool visibility = true)
        {
            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();

            column.HeaderText = header;
            column.ReadOnly = readOnly;
            column.Visible = visibility;
            column.Name = dataProperty;
            foreach (string category in items)
            {
                column.Items.Add(category);
            }
            
            grid.Columns.Add(column);
        }

        public static void AddColumn(DataGridView grid, string dataProperty, string header, bool readOnly = true, bool visibility = true)
        {
            DataGridViewColumn column = new DataGridViewColumn();
            
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            column.CellTemplate = cell;
            column.HeaderText = header;
            column.ReadOnly = readOnly;
            column.Visible = visibility;
            column.Name = dataProperty;
            column.DataPropertyName = dataProperty;
            
            grid.Columns.Add(column);
        }

        public static void InitGrid(DataGridView grid)
        {
            grid.Columns.Clear();
            grid.AutoGenerateColumns = false;
        }
    }
}
