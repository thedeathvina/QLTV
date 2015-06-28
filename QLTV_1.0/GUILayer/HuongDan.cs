using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLTV_1._0.BusinessLogicLayer;
using QLTV_1._0.DataAccessLayer;
using QLTV_1._0.DataTransferObject;

namespace QLTV_1._0
{
    public partial class HuongDan : Form
    {
        public frmMain _main = new frmMain();
        public HuongDan()
        {
            InitializeComponent();

        }

        private void treeView1_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
        }
    }

}
