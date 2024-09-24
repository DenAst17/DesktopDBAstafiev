namespace DesktopDBAstafiev
{
    partial class JoinTablesForm
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
            cmbTable1 = new ComboBox();
            btnJoin = new Button();
            cmbTable2 = new ComboBox();
            cmbColumn = new ComboBox();
            lblDatabaseName = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // cmbTable1
            // 
            cmbTable1.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTable1.Font = new Font("Segoe UI", 14F);
            cmbTable1.FormattingEnabled = true;
            cmbTable1.Location = new Point(154, 15);
            cmbTable1.Name = "cmbTable1";
            cmbTable1.Size = new Size(260, 46);
            cmbTable1.TabIndex = 3;
            // 
            // btnJoin
            // 
            btnJoin.Font = new Font("Segoe UI", 14F);
            btnJoin.Location = new Point(12, 354);
            btnJoin.Name = "btnJoin";
            btnJoin.Size = new Size(402, 55);
            btnJoin.TabIndex = 4;
            btnJoin.Text = "Join tables";
            btnJoin.UseVisualStyleBackColor = true;
            btnJoin.Click += btnJoin_Click;
            // 
            // cmbTable2
            // 
            cmbTable2.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTable2.Font = new Font("Segoe UI", 14F);
            cmbTable2.FormattingEnabled = true;
            cmbTable2.Location = new Point(154, 103);
            cmbTable2.Name = "cmbTable2";
            cmbTable2.Size = new Size(260, 46);
            cmbTable2.TabIndex = 5;
            // 
            // cmbColumn
            // 
            cmbColumn.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbColumn.Font = new Font("Segoe UI", 14F);
            cmbColumn.FormattingEnabled = true;
            cmbColumn.Location = new Point(154, 191);
            cmbColumn.Name = "cmbColumn";
            cmbColumn.Size = new Size(260, 46);
            cmbColumn.TabIndex = 6;
            // 
            // lblDatabaseName
            // 
            lblDatabaseName.AutoSize = true;
            lblDatabaseName.Font = new Font("Segoe UI", 14F);
            lblDatabaseName.Location = new Point(12, 15);
            lblDatabaseName.Margin = new Padding(5, 0, 5, 0);
            lblDatabaseName.Name = "lblDatabaseName";
            lblDatabaseName.Size = new Size(110, 38);
            lblDatabaseName.TabIndex = 7;
            lblDatabaseName.Text = "Table 1:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(12, 103);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(110, 38);
            label1.TabIndex = 8;
            label1.Text = "Table 2:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(12, 194);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(134, 38);
            label2.TabIndex = 9;
            label2.Text = "Column1:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(12, 281);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(134, 38);
            label3.TabIndex = 11;
            label3.Text = "Column2:";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Segoe UI", 14F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(154, 278);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(260, 46);
            comboBox1.TabIndex = 10;
            // 
            // JoinTablesForm
            // 
            ClientSize = new Size(443, 421);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblDatabaseName);
            Controls.Add(cmbColumn);
            Controls.Add(cmbTable2);
            Controls.Add(btnJoin);
            Controls.Add(cmbTable1);
            Name = "JoinTablesForm";
            Text = "Join tables";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbTable1;
        private Button btnJoin;
        private ComboBox cmbTable2;
        private ComboBox cmbColumn;
        private Label lblDatabaseName;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox comboBox1;
    }
}