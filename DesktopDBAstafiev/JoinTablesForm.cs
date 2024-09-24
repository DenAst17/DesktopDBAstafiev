using DesktopDBAstafiev.Classes;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DesktopDBAstafiev
{
    public partial class JoinTablesForm : Form
    {
        private Database database;

        public JoinTablesForm(Database db)
        {
            InitializeComponent();
            database = db;
            LoadTables();
        }

        private void LoadTables()
        {
            // Populate cmbTable1 and cmbTable2 with table names from the database
            cmbTable1.Items.AddRange(database.Tables.Select(t => t.Name).ToArray());
            cmbTable2.Items.AddRange(database.Tables.Select(t => t.Name).ToArray());

            // Handle table selection changes to populate columns
            cmbTable1.SelectedIndexChanged += CmbTable1_SelectedIndexChanged;
            cmbTable2.SelectedIndexChanged += CmbTable2_SelectedIndexChanged;
        }

        private void CmbTable1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Populate cmbColumn with columns of selected table1
            cmbColumn.Items.Clear();
            var table1 = database.Tables.FirstOrDefault(t => t.Name == cmbTable1.SelectedItem.ToString());
            if (table1 != null)
            {
                cmbColumn.Items.AddRange(table1.Columns.Select(c => c.Name).ToArray());
            }
        }

        private void CmbTable2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Populate comboBox1 with columns of selected table2
            comboBox1.Items.Clear();
            var table2 = database.Tables.FirstOrDefault(t => t.Name == cmbTable2.SelectedItem.ToString());
            if (table2 != null)
            {
                comboBox1.Items.AddRange(table2.Columns.Select(c => c.Name).ToArray());
            }
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            // Ensure that all selections are made
            if (cmbTable1.SelectedItem == null || cmbTable2.SelectedItem == null || cmbColumn.SelectedItem == null || comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select both tables and columns for the join.");
                return;
            }

            // Get the selected tables and columns
            var table1 = database.Tables.FirstOrDefault(t => t.Name == cmbTable1.SelectedItem.ToString());
            var table2 = database.Tables.FirstOrDefault(t => t.Name == cmbTable2.SelectedItem.ToString());

            var column1 = table1?.Columns.FirstOrDefault(c => c.Name == cmbColumn.SelectedItem.ToString());
            var column2 = table2?.Columns.FirstOrDefault(c => c.Name == comboBox1.SelectedItem.ToString());

            if (table1 == null || table2 == null || column1 == null || column2 == null)
            {
                MessageBox.Show("Error retrieving selected tables or columns.");
                return;
            }

            try
            {
                // Perform the join
                var resultTable = table1.Join(table2, column1, column2);

                // Add the result table to the database
                database.AddTable(resultTable);

                // Notify success and close the form with OK result
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error joining tables: {ex.Message}");
            }
        }
    }
}
