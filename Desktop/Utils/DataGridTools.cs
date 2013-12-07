using Desktop.UserSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Desktop.Utils
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
        wholesalePrice,
        supplier
    }

    public class ChangeRecord
    {
        public RecordType Type;
        public FieldType Field;
        public int Id;
        public string Value;
    }
    
    public sealed class DataGridTools
    {
        private ACESettings MainSettings;

        public static void SetMainSettings(ACESettings settings)
        {
            instance.MainSettings = settings;
        }

        static readonly DataGridTools instance = new DataGridTools();

        static DataGridTools()
        {
        }

        DataGridTools()
        {
        }

        public static DataGridTools Instance
        {
            get
            {
                return instance;
            }
        }

        public static void AddComboBoxColumn(DataGridView grid, string dataProperty, string header, List<string> items, bool readOnly = true, bool visibility = true)
        {
            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();

            column.HeaderText = header;
            column.ReadOnly = readOnly;
            column.Visible = visibility;
            column.FlatStyle = FlatStyle.Standard;
            column.Name = dataProperty;
            foreach (string category in items)
            {
                column.Items.Add(category);
            }
            
            grid.Columns.Add(column);
        }

        public static void AddCheckBoxColumn(DataGridView grid, string dataProperty, string header, bool readOnly = true, bool visibility = true)
        {
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();

            column.HeaderText = header;
            column.FlatStyle = FlatStyle.Standard;
            column.ReadOnly = readOnly;
            column.Visible = visibility;
            column.Name = dataProperty;
            column.TrueValue = true;
            column.FalseValue = false;
            
            grid.Columns.Add(column);
        }

        public static void AddButtonColumn(DataGridView grid, string dataProperty, string header)
        {
            DataGridViewButtonColumn column = new DataGridViewButtonColumn();

            column.DataPropertyName = dataProperty;
            column.HeaderText = header;
            column.FlatStyle = FlatStyle.Standard;
            column.Name = dataProperty;
            column.Text = header;
            column.UseColumnTextForButtonValue = true;  
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
            column.Width = instance.MainSettings.GetWidth(grid.Name+dataProperty);
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
