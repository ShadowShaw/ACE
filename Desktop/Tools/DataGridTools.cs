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
        category = 0
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
        public static void AddColumn(DataGridView grid, string dataProperty, string header, bool readOnly = true)
        {
            DataGridViewColumn column = new DataGridViewColumn();
            
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            column.CellTemplate = cell;
            column.HeaderText = header;
            column.ReadOnly = readOnly;
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
