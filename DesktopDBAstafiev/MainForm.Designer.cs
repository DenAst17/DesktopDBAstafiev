using DesktopDBAstafiev.Classes;

namespace DesktopDBAstafiev
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbTables = new ComboBox();
            saveButton = new Button();
            loadButton = new Button();
            createTableButton = new Button();
            deleteTableButton = new Button();
            dataGridView = new DataGridView();
            databaseLabel = new Label();
            AddColumnButton = new Button();
            JoinButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // cmbTables
            // 
            cmbTables.Font = new Font("Segoe UI", 14F);
            cmbTables.Location = new Point(693, 630);
            cmbTables.Name = "cmbTables";
            cmbTables.Size = new Size(200, 46);
            cmbTables.TabIndex = 0;
            cmbTables.SelectedIndexChanged += cmbTables_SelectedIndexChanged;
            // 
            // saveButton
            // 
            saveButton.Font = new Font("Segoe UI", 14F);
            saveButton.Location = new Point(20, 73);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(244, 56);
            saveButton.TabIndex = 0;
            saveButton.Text = "Save Database";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += btnSaveDatabase_Click;
            // 
            // loadButton
            // 
            loadButton.Font = new Font("Segoe UI", 14F);
            loadButton.Location = new Point(20, 135);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(244, 52);
            loadButton.TabIndex = 1;
            loadButton.Text = "Load Database";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += btnLoadDatabase_Click;
            // 
            // createTableButton
            // 
            createTableButton.Font = new Font("Segoe UI", 14F);
            createTableButton.Location = new Point(20, 12);
            createTableButton.Name = "createTableButton";
            createTableButton.Size = new Size(244, 55);
            createTableButton.TabIndex = 2;
            createTableButton.Text = "Create Database";
            createTableButton.UseVisualStyleBackColor = true;
            createTableButton.Click += btnCreateDatabase_Click;
            // 
            // deleteTableButton
            // 
            deleteTableButton.Font = new Font("Segoe UI", 14F);
            deleteTableButton.Location = new Point(420, 626);
            deleteTableButton.Name = "deleteTableButton";
            deleteTableButton.Size = new Size(267, 53);
            deleteTableButton.TabIndex = 3;
            deleteTableButton.Text = "Add/Delete Tables";
            deleteTableButton.UseVisualStyleBackColor = true;
            deleteTableButton.Click += btnManageTables_Click;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeight = 34;
            dataGridView.Location = new Point(20, 212);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 62;
            dataGridView.Size = new Size(873, 408);
            dataGridView.TabIndex = 0;
            dataGridView.CellBeginEdit += dataGridView_CellBeginEdit;
            dataGridView.RowLeave += dataGridView_RowLeave;
            dataGridView.RowValidated += dataGridView_RowValidated;
            dataGridView.UserDeletingRow += dataGridView_UserDeletingRow;
            // 
            // databaseLabel
            // 
            databaseLabel.AutoSize = true;
            databaseLabel.Font = new Font("Segoe UI", 14F);
            databaseLabel.Location = new Point(20, 633);
            databaseLabel.Name = "databaseLabel";
            databaseLabel.Size = new Size(229, 38);
            databaseLabel.TabIndex = 5;
            databaseLabel.Text = "Database: (None)";
            // 
            // AddColumnButton
            // 
            AddColumnButton.Font = new Font("Segoe UI", 14F);
            AddColumnButton.Location = new Point(675, 12);
            AddColumnButton.Name = "AddColumnButton";
            AddColumnButton.Size = new Size(218, 66);
            AddColumnButton.TabIndex = 6;
            AddColumnButton.Text = "Add column";
            AddColumnButton.UseVisualStyleBackColor = true;
            AddColumnButton.Click += AddColumnButton_Click;
            // 
            // JoinButton
            // 
            JoinButton.Font = new Font("Segoe UI", 14F);
            JoinButton.Location = new Point(675, 121);
            JoinButton.Name = "JoinButton";
            JoinButton.Size = new Size(218, 66);
            JoinButton.TabIndex = 7;
            JoinButton.Text = "Join tables";
            JoinButton.UseVisualStyleBackColor = true;
            JoinButton.Click += JoinButton_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(905, 692);
            Controls.Add(JoinButton);
            Controls.Add(AddColumnButton);
            Controls.Add(cmbTables);
            Controls.Add(saveButton);
            Controls.Add(loadButton);
            Controls.Add(createTableButton);
            Controls.Add(deleteTableButton);
            Controls.Add(dataGridView);
            Controls.Add(databaseLabel);
            Name = "MainForm";
            Text = "Database Management System";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddColumnButton;
        private Button saveButton;
        private Button loadButton;
        private Button createTableButton;
        private Button deleteTableButton;
        private DataGridView dataGridView;
        private Label databaseLabel;
        private ComboBox cmbTables;
        private Button JoinButton;
    }
}
