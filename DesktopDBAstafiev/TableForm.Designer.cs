namespace DesktopDBAstafiev
{
    partial class TableForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.cmbTables = new System.Windows.Forms.ComboBox();
            this.btnCreateTable = new System.Windows.Forms.Button();
            this.btnDeleteTable = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(12, 12);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(260, 22);
            this.txtTableName.TabIndex = 0;
            this.txtTableName.PlaceholderText = "Enter table name";

            // 
            // cmbTables
            // 
            this.cmbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTables.FormattingEnabled = true;
            this.cmbTables.Location = new System.Drawing.Point(12, 50);
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.Size = new System.Drawing.Size(260, 24);
            this.cmbTables.TabIndex = 1;

            // 
            // btnCreateTable
            // 
            this.btnCreateTable.Location = new System.Drawing.Point(12, 90);
            this.btnCreateTable.Name = "btnCreateTable";
            this.btnCreateTable.Size = new System.Drawing.Size(120, 30);
            this.btnCreateTable.TabIndex = 2;
            this.btnCreateTable.Text = "Create Table";
            this.btnCreateTable.UseVisualStyleBackColor = true;
            this.btnCreateTable.Click += new System.EventHandler(this.btnCreateTable_Click);

            // 
            // btnDeleteTable
            // 
            this.btnDeleteTable.Location = new System.Drawing.Point(152, 90);
            this.btnDeleteTable.Name = "btnDeleteTable";
            this.btnDeleteTable.Size = new System.Drawing.Size(120, 30);
            this.btnDeleteTable.TabIndex = 3;
            this.btnDeleteTable.Text = "Delete Table";
            this.btnDeleteTable.UseVisualStyleBackColor = true;
            this.btnDeleteTable.Click += new System.EventHandler(this.btnDeleteTable_Click);

            // 
            // TableForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 141);
            this.Controls.Add(this.btnDeleteTable);
            this.Controls.Add(this.btnCreateTable);
            this.Controls.Add(this.cmbTables);
            this.Controls.Add(this.txtTableName);
            this.Name = "TableForm";
            this.Text = "Table Management";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}