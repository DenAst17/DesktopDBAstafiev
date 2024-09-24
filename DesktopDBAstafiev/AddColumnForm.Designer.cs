namespace DesktopDBAstafiev
{
    partial class AddColumnForm
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
            txtFieldName = new TextBox();
            cmbFieldType = new ComboBox();
            btnAddField = new Button();
            SuspendLayout();
            // 
            // txtFieldName
            // 
            txtFieldName.Font = new Font("Segoe UI", 14F);
            txtFieldName.Location = new Point(12, 12);
            txtFieldName.Name = "txtFieldName";
            txtFieldName.PlaceholderText = "Column Name";
            txtFieldName.Size = new Size(260, 45);
            txtFieldName.TabIndex = 0;
            // 
            // cmbFieldType
            // 
            cmbFieldType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFieldType.Font = new Font("Segoe UI", 14F);
            cmbFieldType.FormattingEnabled = true;
            cmbFieldType.Items.AddRange(new object[] { "int", "real", "char", "string", "color", "colorInvl" });
            cmbFieldType.Location = new Point(12, 84);
            cmbFieldType.Name = "cmbFieldType";
            cmbFieldType.Size = new Size(260, 46);
            cmbFieldType.TabIndex = 1;
            // 
            // btnAddField
            // 
            btnAddField.Font = new Font("Segoe UI", 14F);
            btnAddField.Location = new Point(12, 203);
            btnAddField.Name = "btnAddField";
            btnAddField.Size = new Size(260, 57);
            btnAddField.TabIndex = 2;
            btnAddField.Text = "Add column";
            btnAddField.UseVisualStyleBackColor = true;
            btnAddField.Click += btnAddField_Click;
            // 
            // AddColumnForm
            // 
            ClientSize = new Size(303, 272);
            Controls.Add(btnAddField);
            Controls.Add(cmbFieldType);
            Controls.Add(txtFieldName);
            Name = "AddColumnForm";
            Text = "Add Column";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}