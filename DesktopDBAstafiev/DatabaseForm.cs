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
    public partial class DatabaseForm : Form
    {
        private Label lblDatabaseName;
        private TextBox txtDatabaseName;
        private Button btnCreateDatabase;
        public Database Database { get; private set; }

        public DatabaseForm()
        {
            InitializeComponent();
        }

        private void btnCreateDatabase_Click(object sender, EventArgs e)
        {
            Database = new Database(txtDatabaseName.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
