using DesktopDBAstafiev.Classes;

namespace DesktopDBAstafiev
{
    public partial class MainForm : Form
    {
        private Record originalRecord = null;
        private Database currentDatabase;
        private string previousCellValue;
        public MainForm()
        {
            InitializeComponent();
        }

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTables.SelectedItem != null && currentDatabase != null)
            {
                string selectedTableName = cmbTables.SelectedItem.ToString();
                var selectedTable = currentDatabase.Tables.FirstOrDefault(t => t.Name == selectedTableName);
                if (selectedTable != null)
                {
                    UpdateDataGridView(selectedTable);
                }
                else
                {
                    // Clear DataGridView if no valid table is found
                    dataGridView.Columns.Clear();
                    dataGridView.Rows.Clear();
                }
            }
        }

        private void btnCreateDatabase_Click(object sender, EventArgs e)
        {
            var dbForm = new DatabaseForm();
            if (dbForm.ShowDialog() == DialogResult.OK)
            {
                currentDatabase = dbForm.Database;
                databaseLabel.Text = "Database: " + currentDatabase.Name;
                PopulateTableComboBox();  // Populate ComboBox after database creation
                MessageBox.Show("Database created successfully!");
            }
        }

        private void btnManageTables_Click(object sender, EventArgs e)
        {
            if (currentDatabase == null)
            {
                MessageBox.Show("No database selected!");
                return;
            }

            var tableForm = new TableForm(currentDatabase);
            if (tableForm.ShowDialog() == DialogResult.OK)
            {
                PopulateTableComboBox();  // Refresh ComboBox after managing tables
            }
        }

        private void PopulateTableComboBox()
        {
            if (currentDatabase != null)
            {
                cmbTables.Items.Clear();
                foreach (var table in currentDatabase.Tables)
                {
                    cmbTables.Items.Add(table.Name);  // Assuming Table has a Name property
                }
                if (cmbTables.Items.Count > 0)
                {
                    cmbTables.SelectedIndex = 0;  // Optionally select the first table by default
                }
            }
        }

        private void btnSaveDatabase_Click(object sender, EventArgs e)
        {
            if (currentDatabase == null)
            {
                MessageBox.Show("No database to save!");
                return;
            }

            var saveLoadForm = new SaveLoadForm();
            saveLoadForm.SaveDatabase(currentDatabase);
        }

        private void btnLoadDatabase_Click(object sender, EventArgs e)
        {
            var saveLoadForm = new SaveLoadForm();
            var loadedDb = saveLoadForm.LoadDatabase();
            if (loadedDb != null)
            {
                currentDatabase = loadedDb;
                databaseLabel.Text = "Database: " + currentDatabase.Name;
                PopulateTableComboBox();
                var selectedTable = currentDatabase.Tables.FirstOrDefault();
                if (selectedTable != null)
                {
                    UpdateDataGridView(selectedTable);
                }
            }
        }

        private void UpdateDataGridView(Table selectedTable)
        {
            // Temporarily disable DataGridView events to prevent errors
            dataGridView.CellBeginEdit -= dataGridView_CellBeginEdit;
            dataGridView.RowLeave -= dataGridView_RowLeave;
            dataGridView.RowValidated -= dataGridView_RowValidated;

            try
            {
                // Clear current rows and columns before adding new ones
                dataGridView.Columns.Clear();
                dataGridView.Rows.Clear();

                // Add columns to DataGridView
                foreach (var column in selectedTable.Columns)
                {
                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = column.Name });
                }

                // Add rows/records to DataGridView
                foreach (var record in selectedTable.Records)
                {
                    var row = new DataGridViewRow();
                    for (int i = 0; i < selectedTable.Columns.Count; i++)
                    {
                        var field = record.Fields[i];
                        row.Cells.Add(new DataGridViewTextBoxCell() { Value = field.Value });
                    }

                    dataGridView.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                // Log or handle exceptions if necessary
                MessageBox.Show($"Error updating DataGridView: {ex.Message}");
            }
            finally
            {
                // Re-enable DataGridView events
                dataGridView.CellBeginEdit += dataGridView_CellBeginEdit;
                dataGridView.RowLeave += dataGridView_RowLeave;
                dataGridView.RowValidated += dataGridView_RowValidated;
            }
        }

        private void AddColumnButton_Click(object sender, EventArgs e)
        {
            if (currentDatabase == null || cmbTables.SelectedItem == null)
            {
                MessageBox.Show("No database or table selected.");
                return;
            }

            string selectedTableName = cmbTables.SelectedItem.ToString();
            var selectedTable = currentDatabase.Tables.FirstOrDefault(t => t.Name == selectedTableName);

            if (selectedTable == null) return;

            // Prompt the user to input column name and data type
            var inputForm = new AddColumnForm(); // Assume this is a custom form to input column name and data type
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                string columnName = inputForm.ColumnName;
                string dataType = inputForm.DataType;

                Column newColumn = new Column(columnName, dataType);
                selectedTable.AddColumn(newColumn);

                // Add new column to DataGridView
                dataGridView.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = columnName });
            }
        }

        private void dataGridView_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (currentDatabase == null || cmbTables.SelectedItem == null) return;

            string selectedTableName = cmbTables.SelectedItem.ToString();
            var selectedTable = currentDatabase.Tables.FirstOrDefault(t => t.Name == selectedTableName);

            if (selectedTable == null) return;

            if (dataGridView.Rows[e.RowIndex].IsNewRow) return;

            Record currentRecord = new Record();
            bool isEmptyRow = true;
            foreach (DataGridViewCell cell in dataGridView.Rows[e.RowIndex].Cells)
            {
                if (cell.Value != null)
                {
                    isEmptyRow = false;
                    Column column = selectedTable.Columns[cell.ColumnIndex];
                    Field field = new Field(column, cell.Value.ToString());

                    // Validating field
                    if (!field.Validate())
                    {
                        MessageBox.Show($"Invalid value in column '{column.Name}' for row {e.RowIndex + 1}");

                        if (e.RowIndex < selectedTable.Records.Count)
                        {
                            dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = previousCellValue;
                        }
                        else
                        {
                            dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                        }
                        return;
                    }

                    currentRecord.AddField(field);
                }
            }

            if (isEmptyRow)
            {
                return;
            }

            // Check if it's an existing record
            if (e.RowIndex < selectedTable.Records.Count)
            {
                // Existing record: check if any changes were made
                if (originalRecord != null && !originalRecord.Equals(currentRecord))
                {
                    // Record was modified, update it
                    selectedTable.Records[e.RowIndex] = currentRecord;
                    MessageBox.Show("Record updated successfully!");
                }
            }

            originalRecord = null;
        }

        private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (currentDatabase == null || cmbTables.SelectedItem == null) return;

            string selectedTableName = cmbTables.SelectedItem.ToString();
            var selectedTable = currentDatabase.Tables.FirstOrDefault(t => t.Name == selectedTableName);

            if (selectedTable == null || e.RowIndex < 0 || e.RowIndex >= selectedTable.Records.Count) return;

            previousCellValue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
        }

        private void dataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (currentDatabase == null || cmbTables.SelectedItem == null) return;

            string selectedTableName = cmbTables.SelectedItem.ToString();
            var selectedTable = currentDatabase.Tables.FirstOrDefault(t => t.Name == selectedTableName);

            if (selectedTable == null) return;

            // Make sure the row index is within bounds
            if (e.RowIndex >= dataGridView.Rows.Count || e.RowIndex < 0) return;

            if (dataGridView.Rows[e.RowIndex].IsNewRow) return;

            Record currentRecord = new Record();
            bool isEmptyRow = true;

            foreach (DataGridViewCell cell in dataGridView.Rows[e.RowIndex].Cells)
            {
                if (cell.Value != null)
                {
                    isEmptyRow = false;
                    Column column = selectedTable.Columns[cell.ColumnIndex];
                    Field field = new Field(column, cell.Value.ToString());

                    // Validating field
                    if (!field.Validate())
                    {
                        MessageBox.Show($"Invalid value in column '{column.Name}' for row {e.RowIndex + 1}");

                        if (e.RowIndex < selectedTable.Records.Count)
                        {
                            dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = previousCellValue;
                        }
                        else
                        {
                            dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                        }
                        return;
                    }

                    currentRecord.AddField(field);
                }
            }

            // If it's a new record, check for validity when leaving the row
            if (e.RowIndex >= selectedTable.Records.Count)
            {
                if (currentRecord.Fields.Count == selectedTable.Columns.Count)
                {
                    selectedTable.AddRecord(currentRecord);
                }
                else
                {
                    if (!isEmptyRow)
                    {
                        MessageBox.Show("The record does not match the table schema.");
                    }
                }
            }
        }

        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (currentDatabase == null || cmbTables.SelectedItem == null) return;

            string selectedTableName = cmbTables.SelectedItem.ToString();
            var selectedTable = currentDatabase.Tables.FirstOrDefault(t => t.Name == selectedTableName);

            if (selectedTable == null) return;

            int rowIndex = e.Row.Index;
            if (rowIndex < 0 || rowIndex >= selectedTable.Records.Count) return;

            selectedTable.Records.RemoveAt(rowIndex);
        }

        private void JoinButton_Click(object sender, EventArgs e)
        {
            if (currentDatabase == null)
            {
                MessageBox.Show("No database loaded!");
                return;
            }

            var joinTablesForm = new JoinTablesForm(currentDatabase);

            if (joinTablesForm.ShowDialog() == DialogResult.OK)
            {
                PopulateTableComboBox();

                cmbTables.SelectedIndex = cmbTables.Items.Count - 1;

                var joinedTable = currentDatabase.Tables.Last();
                UpdateDataGridView(joinedTable);

                MessageBox.Show("Tables joined successfully!");
            }
        }
    }
}
