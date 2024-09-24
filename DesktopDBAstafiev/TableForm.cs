using DesktopDBAstafiev.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopDBAstafiev
{
    public partial class TableForm : Form
    {
        private TextBox txtTableName;
        private ComboBox cmbTables;
        private Button btnCreateTable;
        private Button btnDeleteTable;
        private Database database;

        public TableForm(Database db)
        {
            InitializeComponent();
            database = db;
            PopulateTableComboBox();
        }

        private void PopulateTableComboBox()
        {
            cmbTables.Items.Clear();
            foreach (var table in database.Tables)
            {
                cmbTables.Items.Add(table.Name);
            }
        }

        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            try
            {
                var table = new Table(txtTableName.Text);
                database.AddTable(table);
                MessageBox.Show("Table created successfully!");
                PopulateTableComboBox();  // Refresh ComboBox after table creation
                DialogResult = DialogResult.OK;
                Close();
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            if (cmbTables.SelectedItem != null)
            {
                database.RemoveTable(cmbTables.SelectedItem.ToString());
                MessageBox.Show("Table deleted successfully!");
                PopulateTableComboBox();  // Refresh ComboBox after table deletion
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
