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
    public partial class AddColumnForm : Form
    {
        private TextBox txtFieldName;
        private ComboBox cmbFieldType;
        private Button btnAddField;
        public string ColumnName { get; private set; }
        public string DataType { get; private set; }

        public AddColumnForm()
        {
            InitializeComponent();
        }

        private void btnAddField_Click(object sender, EventArgs e)
        {
            ColumnName = txtFieldName.Text;
            DataType = cmbFieldType.SelectedItem.ToString();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
