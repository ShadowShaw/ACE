using Desktop.UserSettings;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Desktop.Utils
{
    public sealed class DataGridTools
    {
        private ACESettings mainSettings;

        public static void SetMainSettings(ACESettings settings)
        {
            Instance.mainSettings = settings;
        }

        private static readonly DataGridTools Instance = new DataGridTools();

        static DataGridTools()
        {
        }

        DataGridTools()
        {
        }

        public static DataGridTools ToolsInstance
        {
            get
            {
                return Instance;
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
            if (Instance.mainSettings != null)
            {
                column.Width = Instance.mainSettings.GetWidth(grid.Name + dataProperty);                
            }
            column.DataPropertyName = dataProperty;
            
            grid.Columns.Add(column);
        }

        public static void AddNumberColumn(DataGridView grid, string dataProperty, string header, bool readOnly = true, bool visibility = true)
        {
            DataGridViewColumn column = new DataGridViewColumn();

            DataGridViewCell cell = new DataGridViewTextBoxCell();
            column.CellTemplate = cell;
            column.HeaderText = header;
            column.ReadOnly = readOnly;
            column.Visible = visibility;
            column.Name = dataProperty;
            column.Width = Instance.mainSettings.GetWidth(grid.Name + dataProperty);
            column.DataPropertyName = dataProperty;
            column.DefaultCellStyle.Format = "0.00";

            grid.Columns.Add(column);
        }

        public static void InitGrid(DataGridView grid)
        {
            grid.Columns.Clear();
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.RowHeadersVisible = false;
            grid.ReadOnly = false;
            grid.AutoGenerateColumns = false;
        }
    }
}
